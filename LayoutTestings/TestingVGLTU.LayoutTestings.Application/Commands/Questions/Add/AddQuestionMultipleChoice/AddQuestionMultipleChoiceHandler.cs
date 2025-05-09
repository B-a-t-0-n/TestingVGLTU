using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Add.AddQuestionMultipleChoice;

public class AddQuestionMultipleChoiceHandler : ICommandHandler<Guid, AddQuestionMultipleChoiceCommand>
{
    private readonly ILayoutTestingRepository _volunteerRepository;
    private readonly ILogger<AddQuestionMultipleChoiceHandler> _logger;
    private readonly IValidator<AddQuestionMultipleChoiceCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public AddQuestionMultipleChoiceHandler(
        ILayoutTestingRepository volunteerRepository,
        ILogger<AddQuestionMultipleChoiceHandler> logger,
        IValidator<AddQuestionMultipleChoiceCommand> validator,
        [FromKeyedServices(Modules.LayoutTestings)] IUnitOfWork unitOfWork)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<Guid, ErrorList>> Handle(AddQuestionMultipleChoiceCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToErrorList();
        }

        var layoutTestingId = LayoutTestingId.Create(command.LayoutTestingId);

        var layoutTestingResult = await _volunteerRepository.GetById(layoutTestingId, cancellationToken);
        if (layoutTestingResult.IsFailure)
            return layoutTestingResult.Error.ToErrorList();

        var questionId = QuestionId.NewId();

        var text = Text.Create(command.Text);
        if (text.IsFailure)
            return text.Error.ToErrorList();

        var scores = Scores.Create(command.Scores);
        if (scores.IsFailure)
            return scores.Error.ToErrorList();

        var answerOptions = new List<Answer>();
        foreach (var answerOption in command.AnswerOptions)
        {
            var answer = Answer.Create(answerOption);
            if (answer.IsFailure)
                return answer.Error.ToErrorList();

            answerOptions.Add(answer.Value);
        }

        var correctAnswers = new List<Answer>();
        foreach (var correctAnswer in command.CorrectAnswers)
        {
            var answer = Answer.Create(correctAnswer);
            if (answer.IsFailure)
                return answer.Error.ToErrorList();

            correctAnswers.Add(answer.Value);
        }

        var question = Question.CreateQuestionMultipleChoice(
            questionId,
            text.Value,
            scores.Value,
            correctAnswers,
            answerOptions);

        layoutTestingResult.Value.AddQuestion(question);

        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("Question with id {QuestionId} added to layout testing with id {LayoutTestingId}", questionId, command.LayoutTestingId);

        return questionId.Value;
    }
}
