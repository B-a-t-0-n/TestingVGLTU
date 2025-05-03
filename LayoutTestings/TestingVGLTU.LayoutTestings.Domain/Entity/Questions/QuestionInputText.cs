using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

public class QuestionInputText : Question
{
    private List<Answer> _correctAnswers = new();

    //EF Core
    private QuestionInputText(QuestionId id) : base(id) { }

    public QuestionInputText(
        QuestionId id,
        Text text,
        SerialNumber serialNumber,
        Scores scores,
        IEnumerable<Answer> correctAnswers) : base(id, text, scores)
    {
        _correctAnswers = correctAnswers.ToList();
        SetSerialNumber(serialNumber);
    }

    public IReadOnlyList<Answer> CorrectAnswers => _correctAnswers;

    public void SetCorrectAnswers(IEnumerable<Answer> correctAnswers) => _correctAnswers = correctAnswers.ToList();
}
