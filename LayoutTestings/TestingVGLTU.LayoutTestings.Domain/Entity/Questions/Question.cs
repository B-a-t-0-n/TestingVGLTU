using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

public class Question : SharedKernel.Entity<QuestionId>
{
    //EF core
    protected Question(QuestionId id) : base(id) { }
    
    protected Question(
        QuestionId id,
        Text text,
        SerialNumber serialNumber,
        Scores scores) : base(id)
    {
        Text = text;
        SerialNumber = serialNumber;
        Scores = scores;
    }

    public Text Text { get; set; } = default!;
   
    public SerialNumber SerialNumber { get; set; } = default!;

    public Scores Scores { get; set; } = default!;

    public static Question Create(
        QuestionId Id,
        Text text,
        SerialNumber serialNumber,
        Scores scores)
    {
        return new Question(Id, text, serialNumber, scores);
    }
}