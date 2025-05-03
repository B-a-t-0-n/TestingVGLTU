using CSharpFunctionalExtensions;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity;

public class LayoutTesting : SharedKernel.Entity<LayoutTestingId>
{
    private List<Question> _questions = [];

    //EF core
    private LayoutTesting(LayoutTestingId id) : base(id) { }

    private LayoutTesting(
        LayoutTestingId id,
        Title title,
        Attemps attemps, 
        TypeTestingId typeTestingId,
        DateTime time,
        UserId teacherId,
        DateTime createdAt,
        TypeOutPut typeOutPut) : base(id)
    {
        Title = title;
        Attemps = attemps;
        TypeTestingId = typeTestingId;
        Time = time;
        TeacherId = teacherId;
        CreatedAt = createdAt;
        TypeOutPut = typeOutPut;
    }

    public Title Title { get; private set; } = default!;

    public Attemps Attemps { get; private set; } = default!;

    public TypeTestingId TypeTestingId { get; private set; } = default!;

    public TypeTesting TypeTesting { get; private set; } = default!;

    public DateTime Time { get; private set; }

    public UserId TeacherId { get; private set; } = default!;

    public DateTime CreatedAt { get; private set; }

    public TypeOutPut TypeOutPut { get; private set; } = default!;

    public IReadOnlyList<Question> Questions => _questions;

    public static LayoutTesting Create(
        LayoutTestingId id,
        Title title,
        Attemps attemps,
        TypeTestingId typeTestingId,
        DateTime time,
        UserId teacherId,
        DateTime createdAt,
        TypeOutPut typeOutPut)
    {
        return new LayoutTesting(id, title, attemps, typeTestingId, time, teacherId, createdAt, typeOutPut);
    }

    public void AddQuestion(Question question)
    {
        question.SetSerialNumber(SerialNumber.Create(_questions.Count + 1).Value);

        _questions.Add(question);
    }

    public UnitResult<Error> RemoveQuestion(QuestionId id)
    {
        var question = _questions.FirstOrDefault(p => p.Id == id);
        if (question is null)
            return Errors.General.NotFound(id);

        var moveResult = MoveQuestion(question, SerialNumber.Create(_questions.Count).Value);
        if (moveResult.IsFailure)
            return moveResult.Error;

        _questions.Remove(question);

        return Result.Success<Error>();
    }

    public void UpdateInfo(
        Title title,
        Attemps attemps,
        TypeTestingId typeTestingId,
        DateTime time,
        TypeOutPut typeOutPut)
    {
        Title = title;
        Attemps = attemps;
        TypeTestingId = typeTestingId;
        Time = time;
        TypeOutPut = typeOutPut;
    }

    public UnitResult<Error> MoveQuestion(Question question, SerialNumber newSerialNumber)
    {
        var currentSerialNumber = question.SerialNumber;

        if (currentSerialNumber == newSerialNumber || _questions.Count == 1)
            return Result.Success<Error>();

        var adjustedSerialNumber = AdjustNewSerialNumberIfOutOfRange(newSerialNumber);
        if (adjustedSerialNumber.IsFailure)
            return adjustedSerialNumber.Error;

        newSerialNumber = adjustedSerialNumber.Value;

        var moveResult = MoveQuestionBetweenSerialNumbers(newSerialNumber, currentSerialNumber);
        if (moveResult.IsFailure)
            return moveResult.Error;

        question.Move(newSerialNumber);

        return Result.Success<Error>();
    }

    private Result<SerialNumber, Error> AdjustNewSerialNumberIfOutOfRange(SerialNumber newSerialNumber)
    {
        if (newSerialNumber.Value <= _questions.Count)
            return newSerialNumber;

        var lasrSerialNumber = SerialNumber.Create(_questions.Count);
        if (lasrSerialNumber.IsFailure)
            return lasrSerialNumber.Error;

        return lasrSerialNumber.Value;
    }

    private UnitResult<Error> MoveQuestionBetweenSerialNumbers(SerialNumber newSerialNumber, SerialNumber currentSerialNumber)
    {
        if (newSerialNumber.Value < currentSerialNumber.Value)
        {
            var petsToMove = _questions
                .Where(p => p.SerialNumber.Value >= newSerialNumber.Value && p.SerialNumber.Value < currentSerialNumber.Value);

            foreach (var petToMove in petsToMove)
            {
                var result = petToMove.MoveForward();
                if (result.IsFailure)
                    return result.Error;
            }

        }
        else if (newSerialNumber.Value > currentSerialNumber.Value)
        {
            var petsToMove = _questions
                .Where(p => p.SerialNumber.Value > currentSerialNumber.Value && p.SerialNumber.Value <= newSerialNumber.Value);

            foreach (var petToMove in petsToMove)
            {
                var result = petToMove.MoveBack();
                if (result.IsFailure)
                    return result.Error;
            }
        }

        return Result.Success<Error>();
    }

}
