using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.LayoutTestings.Domain.Entity;
using TestingVGLTU.Core.Providers;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;

namespace TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Create;

public class CreateLayoutTestingHandler : ICommandHandler<Guid, CreateLayoutTestingCommand>
{
    private readonly ILayoutTestingRepository _volunteerRepository;
    private readonly ILogger<CreateLayoutTestingHandler> _logger;
    private readonly IValidator<CreateLayoutTestingCommand> _validator;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLayoutTestingHandler(
        ILayoutTestingRepository volunteerRepository,
        ILogger<CreateLayoutTestingHandler> logger,
        IValidator<CreateLayoutTestingCommand> validator,
        IDateTimeProvider dateTimeProvider,
        [FromKeyedServices(Modules.LayoutTestings)] IUnitOfWork unitOfWork)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid, ErrorList>> Handle(CreateLayoutTestingCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToErrorList();
        }

        var layoutTestingId = LayoutTestingId.NewId();

        var title = Title.Create(command.Title);
        if (title.IsFailure)
            return title.Error.ToErrorList();

        var attemps = Attemps.Create(command.Attemps);
        if (attemps.IsFailure)
            return attemps.Error.ToErrorList();

        var typeTestingId = TypeTestingId.Create(command.TypeTestingId);

        var typeOutPut = TypeOutPut.Create(command.TypeOutPut);
        if (typeOutPut.IsFailure)
            return typeOutPut.Error.ToErrorList();

        var createdAt = _dateTimeProvider.UtcNow;

        var time = command.Time;

        var teacherId = UserId.Create(command.TeacherId);

        var layoutTestingResult = LayoutTesting.Create(
            layoutTestingId,
            title.Value,
            attemps.Value,
            typeTestingId,
            time,
            teacherId,
            createdAt,
            typeOutPut.Value);

        await _volunteerRepository.Add(layoutTestingResult, cancellationToken);
        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("created layout Testing with id {layoutTestingId}", layoutTestingId.Value);

        return (Guid)layoutTestingResult.Id;
    }
}
