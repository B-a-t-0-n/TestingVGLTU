using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Add.AddQuestionSingleSelection;

public class AddQuestionSingleSelectionHandler : ICommandHandler<Guid, AddQuestionSingleSelectionCommand>
{
    private readonly ILayoutTestingRepository _volunteerRepository;
    private readonly ILogger<AddQuestionSingleSelectionHandler> _logger;
    private readonly IValidator<AddQuestionSingleSelectionCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public AddQuestionSingleSelectionHandler(
        ILayoutTestingRepository volunteerRepository,
        ILogger<AddQuestionSingleSelectionHandler> logger,
        IValidator<AddQuestionSingleSelectionCommand> validator,
        IUnitOfWork unitOfWork)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<Guid, ErrorList>> Handle(AddQuestionSingleSelectionCommand command, CancellationToken cancellationToken = default)
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

        var answersOptions = new List<Answer>();
        foreach (var answerOption in command.AnswerOptions)
        {
            var answer = Answer.Create(answerOption);
            if (answer.IsFailure)
                return answer.Error.ToErrorList();

            answersOptions.Add(answer.Value);
        }

        var rightAnswer = Answer.Create(command.RightAnswer);
        if (rightAnswer.IsFailure)
            return rightAnswer.Error.ToErrorList();

        var question = Question.CreateQuestionSingleSelection(
            questionId,
            text.Value,
            scores.Value,
            answersOptions,
            rightAnswer.Value);

        layoutTestingResult.Value.AddQuestion(question);

        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("Question with id {QuestionId} added to layout testing with id {LayoutTestingId}", questionId, command.LayoutTestingId);

        return questionId.Value;
    }
}