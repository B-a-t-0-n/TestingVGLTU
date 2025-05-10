using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.RemoveQuestion;

public class RemoveQuestionHandler : ICommandHandler<RemoveQuestionCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILayoutTestingRepository _layoutTestingRepository;
    private readonly IValidator<RemoveQuestionCommand> _validator;
    private readonly ILogger<RemoveQuestionHandler> _logger;

    public RemoveQuestionHandler(
        ILayoutTestingRepository layoutTestingRepository,
        IValidator<RemoveQuestionCommand> validator,
        ILogger<RemoveQuestionHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _layoutTestingRepository = layoutTestingRepository;
        _validator = validator;
        _logger = logger;
    }

    public async Task<UnitResult<ErrorList>> Handle(RemoveQuestionCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToErrorList();
        }

        var layoutTestingId = LayoutTestingId.Create(command.LayoutTestingId);

        var questionId = QuestionId.Create(command.QuestionId);

        var layoutTestingResult = await _layoutTestingRepository.GetById(layoutTestingId, cancellationToken);
        if (layoutTestingResult.IsFailure)
        {
            return layoutTestingResult.Error.ToErrorList();
        }

        var result = layoutTestingResult.Value.RemoveQuestion(questionId);
        if (result.IsFailure)
            return result.Error.ToErrorList();
        
        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("Question with id {QuestionId} removed from layout testing with id {LayoutTestingId}", command.QuestionId, command.LayoutTestingId);

        return Result.Success<ErrorList>();
    }
}
