using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.ActiveTestings.Domain.Entity;

public class History : SharedKernel.Entity<HistoryId>
{
    private List<UserResponse> _userResponses = new();

    private History(HistoryId id) : base(id) { }

    private History(
        HistoryId id,
        ActiveTestingId activeTestingId,
        StudentId studentId,
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

    public ActiveTestingId ActiveTestingId { get; set; } = default!;

    public StudentId StudentId { get; set; } = default!;

    public bool IsComplite { get; set; }

    public DateTime Time { get; set; }

    public Attemps Attemp { get; set; } = default!;

    public IReadOnlyList<UserResponse> UserResponses => _userResponses;

    public static History Create(
        HistoryId id,
        ActiveTestingId activeTestingId,
        StudentId studentId,
        bool isComplite,
        DateTime time,
        Attemps attemp)
    {
        return new History(id, activeTestingId, studentId, isComplite, time, attemp);
    }
}
