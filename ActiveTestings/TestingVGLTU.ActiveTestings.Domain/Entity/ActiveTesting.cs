using CSharpFunctionalExtensions;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.ActiveTestings.Domain.Entity;

public class ActiveTesting : SharedKernel.Entity<ActiveTestingId>
{
    private List<History> _history = [];
    private List<GroupId> _groupsId = [];

    //EF core
    private ActiveTesting(ActiveTestingId id) : base(id) { }

    private ActiveTesting(
        ActiveTestingId id,
        DateTime createdAt,
        DateTime? endDate,
        bool isComplite,
        LayoutTestingId layoutTestingId,
        IEnumerable<GroupId> groupId) : base(id)
    {
        CreatedAt = createdAt;
        EndDate = endDate;
        IsComplite = isComplite;
        LayoutTestingId = layoutTestingId;
        _groupsId = groupId.ToList();
    }

    public DateTime CreatedAt { get; private set; }

    public DateTime? EndDate { get; private set; }

    public bool IsComplite { get; private set; }

    public LayoutTestingId LayoutTestingId { get; private set; } = default!;

    public IReadOnlyList<GroupId> GroupsId => _groupsId;

    public IReadOnlyList<History> History => _history;

    public static ActiveTesting Create(
        ActiveTestingId id,
        DateTime createdAt,
        DateTime? endDate,
        bool isComplite,
        LayoutTestingId layoutTestingId,
        IEnumerable<GroupId> groupsId)
    {
        return new ActiveTesting(id, createdAt, endDate, isComplite, layoutTestingId, groupsId);
    }

    public UnitResult<Error> AddHistory(History history)
    {
        if (_history.Any(h => h.Id == history.Id))
            return Errors.General.AlreadyExist();

        if(IsComplite)
            return Errors.Testing.TestingCompleted();

        if(_history.Any(h => h.StudentId == history.StudentId))
            return Errors.General.AlreadyExist();

        _history.Add(history);

        return UnitResult.Success<Error>();
    }

    public UnitResult<Error> Complite(DateTime endDate)
    {
        if (IsComplite)
            return Errors.Testing.TestingCompleted();

        IsComplite = true;
        EndDate = endDate;
        foreach (var history in _history)
        {
            history.Complite();
        }

        return UnitResult.Success<Error>();
    }

    public UnitResult<Error> CompliteHistory(HistoryId historyId)
    {
        if (IsComplite)
            return Errors.Testing.TestingCompleted();

        var history = _history.FirstOrDefault(h => h.Id == historyId);
        if (history is null)
            return Errors.General.NotFound(historyId);

        history.Complite();

        return UnitResult.Success<Error>();
    }

    public UnitResult<Error> AddUserResponse(UserResponse userResponse)
    {
        if (IsComplite)
            return Errors.Testing.TestingCompleted();

        var history = _history.FirstOrDefault(h => h.Id == userResponse.HistoryId);
        if (history is null)
            return Errors.General.NotFound(userResponse.HistoryId);

        return history.AddUserResponse(userResponse);
    }

    public UnitResult<Error> RestartUserHistoryTesting(HistoryId historyId)
    {
        if (IsComplite)
            return Errors.Testing.TestingCompleted();

        var history = _history.FirstOrDefault(h => h.Id == historyId);
        if (history is null)
            return Errors.General.NotFound(historyId);

        return history.Restart();
    }

    public UnitResult<Error> StopUserHistoryTesting(HistoryId historyId, DateTime time)
    {
        if (IsComplite)
            return Errors.Testing.TestingCompleted();

        var history = _history.FirstOrDefault(h => h.Id == historyId);
        if (history is null)
            return Errors.General.NotFound(historyId);

        return history.Stop(time);
    }
}