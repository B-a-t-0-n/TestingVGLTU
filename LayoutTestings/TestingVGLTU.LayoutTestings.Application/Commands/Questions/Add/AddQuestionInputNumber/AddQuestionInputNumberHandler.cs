using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Add.AddQuestionInputNumber;

public class AddQuestionInputNumberHandler : ICommandHandler<Guid, AddQuestionInputNumberCommand>
{
    private readonly ILayoutTestingRepository _volunteerRepository;
    private readonly ILogger<AddQuestionInputNumberHandler> _logger;
    private readonly IValidator<AddQuestionInputNumberCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public AddQuestionInputNumberHandler(
        ILayoutTestingRepository volunteerRepository,
        ILogger<AddQuestionInputNumberHandler> logger,
        IValidator<AddQuestionInputNumberCommand> validator,
        IUnitOfWork unitOfWork)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<Guid, ErrorList>> Handle(AddQuestionInputNumberCommand command, CancellationToken cancellationToken = default)
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

        var correctAnswers = new List<Answer>();
        foreach (var correctAnswer in command.CorrectAnswers)
        {
            var answer = Answer.Create(correctAnswer);
            if (answer.IsFailure)
                return answer.Error.ToErrorList();

            correctAnswers.Add(answer.Value);
        }

        var question = Question.CreateQuestionInputNumber(
            questionId,
            text.Value,
            scores.Value,
            correctAnswers);

        layoutTestingResult.Value.AddQuestion(question);

        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("Question with id {QuestionId} added to layout testing with id {LayoutTestingId}", questionId, command.LayoutTestingId);

        return questionId.Value;
    }
}
