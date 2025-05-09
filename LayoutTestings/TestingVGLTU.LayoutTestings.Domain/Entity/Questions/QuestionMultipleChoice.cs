using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

public class QuestionMultipleChoice : Question
{
    private List<Answer> _correctAnswers = new();

    private List<Answer> _answerOptions = new();

    //EF Core
    private QuestionMultipleChoice(QuestionId id) : base(id) { }

    internal QuestionMultipleChoice(
        QuestionId id,
        Text text,
        Scores scores,
        IEnumerable<Answer> correctAnswers,
        IEnumerable<Answer> answerOptions) : base(id, text, scores)
    {
        _correctAnswers = correctAnswers.ToList();
        _answerOptions = answerOptions.ToList();
    }

    public IReadOnlyList<Answer> CorrectAnswers => _correctAnswers;

    public IReadOnlyList<Answer> AnswerOptions => _answerOptions;

    internal void SetCorrectAnswers(IEnumerable<Answer> correctAnswers) => _correctAnswers = correctAnswers.ToList();

    internal void SetAnswerOptions(IEnumerable<Answer> answerOptions) => _answerOptions = answerOptions.ToList();

}
