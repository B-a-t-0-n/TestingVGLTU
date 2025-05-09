using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateQuestionMainInfo;

public record UpdateQuestionMainInfoCommand(
    Guid LayoutTestingId,
    Guid QuestionId,
    string Text,
    int Scores) : ICommand;
