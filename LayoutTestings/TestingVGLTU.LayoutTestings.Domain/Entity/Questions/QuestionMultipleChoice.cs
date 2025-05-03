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

    public QuestionMultipleChoice(
        QuestionId id,
        Text text,
        SerialNumber serialNumber,
        Scores scores,
        IEnumerable<Answer> correctAnswers,
        IEnumerable<Answer> answerOptions) : base(id, text, scores)
    {
        _correctAnswers = correctAnswers.ToList();
        _answerOptions = answerOptions.ToList();
        SetSerialNumber(serialNumber);
    }

    public IReadOnlyList<Answer> CorrectAnswers => _correctAnswers;

    public IReadOnlyList<Answer> AnswerOptions => _answerOptions;

    public void SetCorrectAnswers(IEnumerable<Answer> correctAnswers) => _correctAnswers = correctAnswers.ToList();

    public void SetAnswerOptions(IEnumerable<Answer> answerOptions) => _answerOptions = answerOptions.ToList();

}
