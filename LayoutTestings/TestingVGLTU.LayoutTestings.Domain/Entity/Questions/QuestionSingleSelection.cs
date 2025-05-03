using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

public class QuestionSingleSelection : Question
{
    private List<Answer> _answerOptions = new();

    //EF Core
    private QuestionSingleSelection(QuestionId id) : base(id) { }

    public QuestionSingleSelection(
        QuestionId id,
        Text text,
        SerialNumber serialNumber,
        Scores scores,
        IEnumerable<Answer> answerOptions,
        Answer rightAnswer) : base(id, text, scores)
    {
        _answerOptions = answerOptions.ToList();
        RightAnswer = rightAnswer;
        SetSerialNumber(serialNumber);
    }

    public IReadOnlyList<Answer> AnswerOptions => _answerOptions;
    public Answer RightAnswer { get; private set; } = null!;

    public void SetRightAnswer(Answer rightAnswer) => RightAnswer = rightAnswer;

    public void SetAnswerOptions(IEnumerable<Answer> answerOptions) => _answerOptions = answerOptions.ToList();
}
