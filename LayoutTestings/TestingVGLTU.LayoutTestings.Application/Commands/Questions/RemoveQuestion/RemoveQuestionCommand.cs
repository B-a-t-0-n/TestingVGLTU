using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.RemoveQuestion;

public record RemoveQuestionCommand(Guid LayoutTestingId, Guid QuestionId) : ICommand;
