using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateAnswerQuestionMultipleChoice;

public record UpdateAnswerQuestionMultipleChoiceCommand(
    Guid LayoutTestingId,
    Guid QuestionId,
    IEnumerable<string> CorrectAnswers,
    IEnumerable<string> AnswersOptions) : ICommand;
