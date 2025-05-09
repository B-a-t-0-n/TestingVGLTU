using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateAnswersSingleSelection;

public record UpdateAnswersQuestionSingleSelectionCommand(
    Guid LayoutTestingId,
    Guid QuestionId,
    IEnumerable<string> AnswersOptions,
    string RightAnswer) : ICommand;
