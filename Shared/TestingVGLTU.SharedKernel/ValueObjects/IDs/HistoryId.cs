using CSharpFunctionalExtensions;

namespace TestingVGLTU.SharedKernel.ValueObjects.IDs;

public class HistoryId : ComparableValueObject
{
    private HistoryId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static HistoryId NewId() => new(Guid.NewGuid());

    public static HistoryId Empty() => new(Guid.Empty);

    public static HistoryId Create(Guid id) => new(id);

    public static implicit operator Guid(HistoryId id) => id.Value;

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}