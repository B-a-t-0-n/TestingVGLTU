using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateAnswersQuestionInputNumber;

public record UpdateAnswersQuestionInputNumberCommand(
    Guid LayoutTestingId,
    Guid QuestionId,
    IEnumerable<string> CorrectAnswers) : ICommand;
