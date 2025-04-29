using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

public class QuestionSingleSelection : Question
{
    //EF Core
    private QuestionSingleSelection(QuestionId id) : base(id) { }

    public QuestionSingleSelection(
        QuestionId id,
        Text text,
        SerialNumber serialNumber,
        Scores scores,
        Answer[] answerOptions,
        Answer rightAnswer) : base(id, text, serialNumber, scores)
    {
        AnswerOptions = answerOptions;
        RightAnswer = rightAnswer;
    }

    public Answer[] AnswerOptions { get; set; } = null!;
    public Answer RightAnswer { get; set; } = null!;
}
