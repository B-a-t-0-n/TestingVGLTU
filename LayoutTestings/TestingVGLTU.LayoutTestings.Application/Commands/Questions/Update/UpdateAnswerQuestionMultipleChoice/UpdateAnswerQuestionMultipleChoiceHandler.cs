using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.SharedKernel;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateAnswerQuestionMultipleChoice;

public class UpdateAnswerQuestionMultipleChoiceHandler : ICommandHandler<Guid, UpdateAnswerQuestionMultipleChoiceCommand>
{
    private readonly ILayoutTestingRepository _volunteerRepository;
    private readonly ILogger<UpdateAnswerQuestionMultipleChoiceHandler> _logger;
    private readonly IValidator<UpdateAnswerQuestionMultipleChoiceCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAnswerQuestionMultipleChoiceHandler(
        ILayoutTestingRepository volunteerRepository,
        ILogger<UpdateAnswerQuestionMultipleChoiceHandler> logger,
        IValidator<UpdateAnswerQuestionMultipleChoiceCommand> validator,
        IUnitOfWork unitOfWork)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<Guid, ErrorList>> Handle(UpdateAnswerQuestionMultipleChoiceCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToErrorList();
        }

        var layoutTestingId = LayoutTestingId.Create(command.LayoutTestingId);

        var questionId = QuestionId.Create(command.QuestionId);

        var layoutTestingResult = await _volunteerRepository.GetById(layoutTestingId, cancellationToken);
        if (layoutTestingResult.IsFailure)
            return layoutTestingResult.Error.ToErrorList();

        var answersOptions = new List<Answer>();
        foreach (var answer in command.AnswersOptions)
        {
            var answerResult = Answer.Create(answer);
            if (answerResult.IsFailure)
                return answerResult.Error.ToErrorList();

            answersOptions.Add(answerResult.Value);
        }

        var correctAnswers = new List<Answer>();
        foreach (var answer in command.CorrectAnswers)
        {
            var answerResult = Answer.Create(answer);
            if (answerResult.IsFailure)
                return answerResult.Error.ToErrorList();

            correctAnswers.Add(answerResult.Value);
        }

        var result = layoutTestingResult.Value.UpdateAnswersQuestionMultipleChoice(
            questionId,
            answersOptions,
            correctAnswers);
        if (result.IsFailure)
            return result.Error.ToErrorList();

        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation(
            "Update question with id {QuestionId} in layout testing with id {LayoutTestingId}",
            questionId.Value,
            layoutTestingId.Value);

        return questionId.Value;
    }
}
