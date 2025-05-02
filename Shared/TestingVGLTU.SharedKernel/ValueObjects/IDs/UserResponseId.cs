using CSharpFunctionalExtensions;

namespace TestingVGLTU.SharedKernel.ValueObjects.IDs;

public class UserResponseId : ComparableValueObject
{
    private UserResponseId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static UserResponseId NewId() => new(Guid.NewGuid());

    public static UserResponseId Empty() => new(Guid.Empty);

    public static UserResponseId Create(Guid id) => new(id);

    public static implicit operator Guid(UserResponseId id) => id.Value;

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}
