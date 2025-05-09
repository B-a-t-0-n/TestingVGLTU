using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

public class QuestionInputText : Question
{
    private List<Answer> _correctAnswers = new();

    //EF Core
    private QuestionInputText(QuestionId id) : base(id) { }

    internal QuestionInputText(
        QuestionId id,
        Text text,
        Scores scores,
        IEnumerable<Answer> correctAnswers) : base(id, text, scores)
    {
        _correctAnswers = correctAnswers.ToList();
    }

    public IReadOnlyList<Answer> CorrectAnswers => _correctAnswers;

    internal void SetCorrectAnswers(IEnumerable<Answer> correctAnswers) => _correctAnswers = correctAnswers.ToList();
}
