using CSharpFunctionalExtensions;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.ActiveTestings.Domain.Entity;

public class History : SharedKernel.Entity<HistoryId>
{
    private List<UserResponse> _userResponses = new();

    private History(HistoryId id) : base(id) { }

    private History(
        HistoryId id,
        ActiveTestingId activeTestingId,
        UserId studentId,
        bool isComplite,
        DateTime time,
        Attemps attemp) : base(id)
    {
        ActiveTestingId = activeTestingId;
        StudentId = studentId;
        IsComplite = isComplite;
        Time = time;
        Attemp = attemp;
    }

    public ActiveTestingId ActiveTestingId { get; private set; } = default!;

    public UserId StudentId { get; private set; } = default!;

    public bool IsComplite { get; private set; }

    public DateTime Time { get; private set; }

    public Attemps Attemp { get; private set; } = default!;

    public IReadOnlyList<UserResponse> UserResponses => _userResponses;

    public static History Create(
        HistoryId id,
        ActiveTestingId activeTestingId,
        UserId studentId,
        bool isComplite,
        DateTime time,
        Attemps attemp)
    {
        return new History(id, activeTestingId, studentId, isComplite, time, attemp);
    }

    internal void Complite()
    {
        IsComplite = true;
    }

    internal UnitResult<Error> AddUserResponse(UserResponse userResponse)
    {
        if (IsComplite)
            return Errors.Testing.TestingCompleted();

        if (_userResponses.Any(h => h.Id == userResponse.Id))
            return Errors.General.AlreadyExist();

        if (_userResponses.Any(h => h.QuestionId == userResponse.QuestionId))
        {
            var oldUserResponce = _userResponses.FirstOrDefault(h => h.QuestionId == userResponse.QuestionId);
            _userResponses.Remove(oldUserResponce!);

            _userResponses.Add(userResponse);
        }
        else
        {
            _userResponses.Add(userResponse);
        }

        return UnitResult.Success<Error>();
    }

    internal UnitResult<Error> Restart()
    {
        if (IsComplite)
            return Errors.Testing.TestingCompleted();
        if (Attemp.Value <= 0)
            return Errors.Testing.AttemptsEnded();

        _userResponses.Clear();
        IsComplite = false;

        Attemp = Attemps.Create(Attemp.Value - 1).Value;

        return UnitResult.Success<Error>();
    }

    internal UnitResult<Error> Stop(DateTime time)
    {
        if (IsComplite)
            return Errors.Testing.TestingCompleted();

        Time = time;

        return UnitResult.Success<Error>();
    }
}
