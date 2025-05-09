using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Add.AddQuestionInputText;

public record AddQuestionInputTextCommand(Guid LayoutTestingId, string Text, int Scores, IEnumerable<string> CorrectAnswers) : ICommand;
