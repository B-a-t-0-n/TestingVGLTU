using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

public class QuestionMultipleChoice : Question
{
    //EF Core
    private QuestionMultipleChoice(QuestionId id) : base(id) { }

    public QuestionMultipleChoice(
        QuestionId id,
        Text text,
        SerialNumber serialNumber,
        Scores scores,
        Answer[] answerOptions,
        Answer[] correctAnswers) : base(id, text, serialNumber, scores)
    {
        AnswerOptions = answerOptions;
        CorrectAnswers = correctAnswers;
    }

    public Answer[] AnswerOptions { get; set; } = null!;
    public Answer[] CorrectAnswers { get; set; } = null!;
}
