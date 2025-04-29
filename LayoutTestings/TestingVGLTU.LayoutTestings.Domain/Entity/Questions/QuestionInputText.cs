using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

public class QuestionInputText : Question
{
    //EF Core
    private QuestionInputText(QuestionId id) : base(id) { }

    public QuestionInputText(
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
