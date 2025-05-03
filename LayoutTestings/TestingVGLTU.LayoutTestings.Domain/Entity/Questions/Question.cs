using CSharpFunctionalExtensions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel;
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
        Scores scores) : base(id)
    {
        Text = text;
        Scores = scores;
    }

    public Text Text { get; private set; } = default!;
   
    public SerialNumber SerialNumber { get; private set; } = default!;

    public Scores Scores { get; private set; } = default!;

    public static Question Create(
        QuestionId Id,
        Text text,
        Scores scores)
    {
        return new Question(Id, text, scores);
    }

    internal void UpdateMainInfo(
        Text text,
        Scores scores)
    {
        Text = text;
        Scores = scores;
    }

    internal void SetSerialNumber(SerialNumber serialNumber) => SerialNumber = serialNumber;

    internal UnitResult<Error> MoveForward()
    {
        var newSerialNumber = SerialNumber.Forward();
        if (newSerialNumber.IsFailure)
            return newSerialNumber.Error;

        SerialNumber = newSerialNumber.Value;

        return Result.Success<Error>();
    }

    internal UnitResult<Error> MoveBack()
    {
        var newSerialNumber = SerialNumber.Back();
        if (newSerialNumber.IsFailure)
            return newSerialNumber.Error;

        SerialNumber = newSerialNumber.Value;

        return Result.Success<Error>();
    }

    internal void Move(SerialNumber newSerialNumber) => SerialNumber = newSerialNumber;
}