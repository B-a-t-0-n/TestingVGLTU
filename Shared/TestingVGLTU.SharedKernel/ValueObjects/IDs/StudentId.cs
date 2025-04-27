using CSharpFunctionalExtensions;

namespace TestingVGLTU.SharedKernel.ValueObjects.IDs;

public class StudentId : ComparableValueObject
{
    private StudentId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static StudentId NewId() => new(Guid.NewGuid());

    public static StudentId Empty() => new(Guid.Empty);

    public static StudentId Create(Guid id) => new(id);

    public static implicit operator Guid(StudentId id) => id.Value;

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}
