using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateAnswersQuestionInputText;

public record UpdateAnswersQuestionInputTextCommand(
    Guid LayoutTestingId,
    Guid QuestionId,
    IEnumerable<string> CorrectAnswers) : ICommand;
