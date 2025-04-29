using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

public class QuestionInputNumber : Question
{
    //EF Core
    private QuestionInputNumber(QuestionId id) : base(id) { }

    public QuestionInputNumber(
        QuestionId id,
        Text text,
        SerialNumber serialNumber,
        Scores scores,
        Answer[] correctAnswers) : base(id, text, serialNumber, scores)
    {
        CorrectAnswers = correctAnswers;
    }

    public Answer[] CorrectAnswers { get; set; } = null!;
}
