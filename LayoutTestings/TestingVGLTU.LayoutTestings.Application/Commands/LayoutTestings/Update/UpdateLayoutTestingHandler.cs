using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.Core.Extentions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Update;

public class UpdateLayoutTestingHandler : ICommandHandler<Guid, UpdateLayoutTestingCommand>
{
    private readonly ILayoutTestingRepository _volunteerRepository;
    private readonly ILogger<UpdateLayoutTestingHandler> _logger;
    private readonly IValidator<UpdateLayoutTestingCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLayoutTestingHandler(
        ILayoutTestingRepository volunteerRepository,
        ILogger<UpdateLayoutTestingHandler> logger,
        IValidator<UpdateLayoutTestingCommand> validator,
        IUnitOfWork unitOfWork)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<Guid, ErrorList>> Handle(UpdateLayoutTestingCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToErrorList();
        }

        var layoutTestingId = LayoutTestingId.Create(command.Id);

        var layoutTestingResult = await _volunteerRepository.GetById(layoutTestingId, cancellationToken);
        if (layoutTestingResult.IsFailure)
            return layoutTestingResult.Error.ToErrorList();

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

        var time = command.Time;

        layoutTestingResult.Value.UpdateInfo(
            title.Value,
            attemps.Value,
            typeTestingId,
            time,
            typeOutPut.Value);

        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("update main info layout Testing with id {layoutTestingId}", layoutTestingId.Value);

        return (Guid)layoutTestingResult.Value.Id;
    }
}