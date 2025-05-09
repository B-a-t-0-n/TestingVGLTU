using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

public class QuestionSingleSelection : Question
{
    private List<Answer> _answerOptions = new();

    //EF Core
    private QuestionSingleSelection(QuestionId id) : base(id) { }

    internal QuestionSingleSelection(
        QuestionId id,
        Text text,
        Scores scores,
        IEnumerable<Answer> answerOptions,
        Answer rightAnswer) : base(id, text, scores)
    {
        _answerOptions = answerOptions.ToList();
        RightAnswer = rightAnswer;
    }

    public IReadOnlyList<Answer> AnswerOptions => _answerOptions;
    public Answer RightAnswer { get; private set; } = null!;

    internal void SetRightAnswer(Answer rightAnswer) => RightAnswer = rightAnswer;

    internal void SetAnswerOptions(IEnumerable<Answer> answerOptions) => _answerOptions = answerOptions.ToList();
}
