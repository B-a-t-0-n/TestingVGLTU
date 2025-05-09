using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Delete;

public class DeleteLayoutTestingHandler : ICommandHandler<DeleteLayoutTestingCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILayoutTestingRepository _layoutTestingRepository;
    private readonly IValidator<DeleteLayoutTestingCommand> _validator;
    private readonly ILogger<DeleteLayoutTestingHandler> _logger;

    public DeleteLayoutTestingHandler(
        ILayoutTestingRepository layoutTestingRepository,
        IValidator<DeleteLayoutTestingCommand> validator,
        ILogger<DeleteLayoutTestingHandler> logger,
        [FromKeyedServices(Modules.LayoutTestings)] IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _layoutTestingRepository = layoutTestingRepository;
        _validator = validator;
        _logger = logger;
    }
    public async Task<UnitResult<ErrorList>> Handle(DeleteLayoutTestingCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToErrorList();
        }

        var layoutTestingId = LayoutTestingId.Create(command.Id);

        var layoutTestingResult = await _layoutTestingRepository.GetById(layoutTestingId, cancellationToken);
        if (layoutTestingResult.IsFailure)
        {
            return layoutTestingResult.Error.ToErrorList();
        }

        _layoutTestingRepository.Delete(layoutTestingResult.Value, cancellationToken);

        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("LayoutTesting with id {Id} deleted", command.Id);

        return Result.Success<ErrorList>();
    }
}
