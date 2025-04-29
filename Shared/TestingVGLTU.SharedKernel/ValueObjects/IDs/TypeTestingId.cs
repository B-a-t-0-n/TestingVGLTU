using CSharpFunctionalExtensions;

namespace TestingVGLTU.SharedKernel.ValueObjects.IDs;

public class TypeTestingId : ComparableValueObject
{
    private TypeTestingId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static TypeTestingId NewId() => new(Guid.NewGuid());

    public static TypeTestingId Empty() => new(Guid.Empty);

    public static TypeTestingId Create(Guid id) => new(id);

    public static implicit operator Guid(TypeTestingId id) => id.Value;

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}