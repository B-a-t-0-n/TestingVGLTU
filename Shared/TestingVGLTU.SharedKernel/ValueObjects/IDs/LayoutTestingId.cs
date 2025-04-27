using CSharpFunctionalExtensions;

namespace TestingVGLTU.SharedKernel.ValueObjects.IDs;

public class LayoutTestingId : ComparableValueObject
{
    private LayoutTestingId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static LayoutTestingId NewId() => new(Guid.NewGuid());

    public static LayoutTestingId Empty() => new(Guid.Empty);

    public static LayoutTestingId Create(Guid id) => new(id);

    public static implicit operator Guid(LayoutTestingId id) => id.Value;

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}
