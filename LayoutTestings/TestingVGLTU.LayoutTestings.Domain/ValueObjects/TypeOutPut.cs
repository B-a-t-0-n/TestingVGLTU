using CSharpFunctionalExtensions;
using TestingVGLTU.SharedKernel;

namespace TestingVGLTU.LayoutTestings.Domain.ValueObjects;

public class TypeOutPut : ValueObject
{
    private TypeOutPut() { }
    private TypeOutPut(string value)
    {
        Value = value;
    }

    public static readonly TypeOutPut TestComplited = new(nameof(TestComplited));
    public static readonly TypeOutPut TestFinalized = new(nameof(TestFinalized));
    public static readonly TypeOutPut QuestionAnswered = new(nameof(QuestionAnswered));


    public static readonly TypeOutPut[] All = [TestComplited!, TestFinalized!, QuestionAnswered!];

    public string Value { get; } = default!;

    public static Result<TypeOutPut, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsInvalid("TypeOutPut");

        var valueInput = value.Trim().ToLower();

        if (All.Any(s => s.Value.ToLower() == valueInput) == false)
            return Errors.General.ValueIsInvalid("TypeOutPut");

        var assistanceStatus = new TypeOutPut(valueInput);

        return assistanceStatus;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Value;
    }
}
