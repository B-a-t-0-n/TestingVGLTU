using CSharpFunctionalExtensions;

namespace TestingVGLTU.SharedKernel.ValueObjects.IDs;

public class QuestionId : ComparableValueObject
{
    private QuestionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static QuestionId NewId() => new(Guid.NewGuid());

    public static QuestionId Empty() => new(Guid.Empty);

    public static QuestionId Create(Guid id) => new(id);

    public static implicit operator Guid(QuestionId id) => id.Value;

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}
