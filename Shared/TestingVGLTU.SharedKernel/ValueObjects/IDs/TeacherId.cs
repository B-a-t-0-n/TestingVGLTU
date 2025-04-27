using CSharpFunctionalExtensions;

namespace TestingVGLTU.SharedKernel.ValueObjects.IDs;

public class TeacherId : ComparableValueObject
{
    private TeacherId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static TeacherId NewId() => new(Guid.NewGuid());

    public static TeacherId Empty() => new(Guid.Empty);

    public static TeacherId Create(Guid id) => new(id);

    public static implicit operator Guid(TeacherId id) => id.Value;

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}
