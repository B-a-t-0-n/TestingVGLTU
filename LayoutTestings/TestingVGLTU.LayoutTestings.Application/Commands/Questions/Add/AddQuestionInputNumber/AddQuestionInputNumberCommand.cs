using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Add.AddQuestionInputNumber;

public record AddQuestionInputNumberCommand(Guid LayoutTestingId, string Text, int Scores, IEnumerable<string> CorrectAnswers) : ICommand;
