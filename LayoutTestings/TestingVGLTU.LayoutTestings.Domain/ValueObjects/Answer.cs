using CSharpFunctionalExtensions;
using TestingVGLTU.SharedKernel;

namespace TestingVGLTU.LayoutTestings.Domain.ValueObjects;

public class Answer : ValueObject
{
    private Answer() { }
    private Answer(string value)
    {
        Value = value;
    }
   
    public string Value { get; } = default!;

    public static Result<Answer, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsInvalid("answer");

        if (value.Length > Constants.MAX_HIGHT_TEXT_LENGTH)
            return Errors.General.ValueIsInvalid("answer");

        var answer = new Answer(value);

        return answer;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Value;
    }
}