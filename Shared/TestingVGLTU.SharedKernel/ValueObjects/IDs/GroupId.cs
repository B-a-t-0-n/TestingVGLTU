using CSharpFunctionalExtensions;

namespace TestingVGLTU.SharedKernel.ValueObjects.IDs;

public class GroupId : ComparableValueObject
{
    private GroupId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static GroupId NewId() => new(Guid.NewGuid());

    public static GroupId Empty() => new(Guid.Empty);

    public static GroupId Create(Guid id) => new(id);

    public static implicit operator Guid(GroupId id) => id.Value;

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}
