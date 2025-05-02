using CSharpFunctionalExtensions;

namespace TestingVGLTU.SharedKernel.ValueObjects.IDs;

public class ActiveTestingId : ComparableValueObject
{
    private ActiveTestingId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static ActiveTestingId NewId() => new(Guid.NewGuid());

    public static ActiveTestingId Empty() => new(Guid.Empty);

    public static ActiveTestingId Create(Guid id) => new(id);

    public static implicit operator Guid(ActiveTestingId id) => id.Value;

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}
