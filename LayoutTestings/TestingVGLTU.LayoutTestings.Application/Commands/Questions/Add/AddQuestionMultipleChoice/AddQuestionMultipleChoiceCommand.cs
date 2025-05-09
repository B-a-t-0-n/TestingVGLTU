using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Add.AddQuestionMultipleChoice;

public record AddQuestionMultipleChoiceCommand(Guid LayoutTestingId, string Text, int Scores, IEnumerable<string> AnswerOptions, IEnumerable<string> CorrectAnswers) : ICommand;
