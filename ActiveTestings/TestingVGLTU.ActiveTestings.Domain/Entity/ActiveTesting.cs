using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.ActiveTestings.Domain.Entity;

public class ActiveTesting : SharedKernel.Entity<ActiveTestingId>
{
    private List<History> _history = [];

    //EF core
    private ActiveTesting(ActiveTestingId id) : base(id) { }

    private ActiveTesting(
        ActiveTestingId id,
        DateTime createdAt,
        DateTime? endDate,
        bool isComplite,
        LayoutTestingId layoutTestingId,
        GroupId groupId) : base(id)
    {
        CreatedAt = createdAt;
        EndDate = endDate;
        IsComplite = isComplite;
        LayoutTestingId = layoutTestingId;
        GroupId = groupId;
    }

    public DateTime CreatedAt { get; set; }

    public DateTime? EndDate { get; set; }

    public bool IsComplite { get; set; }

    public LayoutTestingId LayoutTestingId { get; set; } = default!;

    public GroupId GroupId { get; set; } = default!;

    public IReadOnlyList<History> History => _history;

    public static ActiveTesting Create(
        ActiveTestingId id,
        DateTime createdAt,
        DateTime? endDate,
        bool isComplite,
        LayoutTestingId layoutTestingId,
        GroupId groupId
        )
    {
        return new ActiveTesting(id, createdAt, endDate, isComplite, layoutTestingId, groupId);
    }
}
