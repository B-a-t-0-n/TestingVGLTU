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
}
