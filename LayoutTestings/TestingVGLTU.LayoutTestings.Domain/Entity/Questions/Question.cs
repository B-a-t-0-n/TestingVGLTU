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

    public QuestionInputNumber? QuestionInputNumber { get; private set; }

    public QuestionInputText? QuestionInputText { get; private set; }
    
    public QuestionMultipleChoice? QuestionMultipleChoice { get; private set; }
    
    public QuestionSingleSelection? QuestionSingleSelection { get; private set; }

    public LayoutTesting LayoutTesting { get; private set; } = default!;

    public LayoutTestingId LayoutTestingId { get; private set; }

    public static Question CreateQuestionInputNumber(
        QuestionId Id,
        Text text,
        Scores scores,
        IEnumerable<Answer> correctAnswers)
    {
        return new QuestionInputNumber(Id, text, scores, correctAnswers);
    }

    public static Question CreateQuestionMultipleChoice(
        QuestionId Id,
        Text text,
        Scores scores,
        IEnumerable<Answer> correctAnswers,
        IEnumerable<Answer> answerOptions)
    {
        return new QuestionMultipleChoice(Id, text, scores, correctAnswers, answerOptions);
    }

    public static Question CreateQuestionSingleSelection(
        QuestionId Id,
        Text text,
        Scores scores,
        IEnumerable<Answer> answerOptions,
        Answer rightAnswer)
    {
        return new QuestionSingleSelection(Id, text, scores, answerOptions, rightAnswer);
    }

    public static Question CreateQuestionInputText(
        QuestionId Id,
        Text text,
        Scores scores,
        IEnumerable<Answer> correctAnswers)
    {
        return new QuestionInputText(Id, text, scores, correctAnswers);
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