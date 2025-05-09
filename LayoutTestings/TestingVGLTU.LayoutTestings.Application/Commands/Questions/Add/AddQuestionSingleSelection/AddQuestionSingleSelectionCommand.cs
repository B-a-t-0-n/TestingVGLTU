using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Add.AddQuestionSingleSelection;

public record AddQuestionSingleSelectionCommand(Guid LayoutTestingId, string Text, int Scores, IEnumerable<string> AnswerOptions, string RightAnswer) : ICommand;
