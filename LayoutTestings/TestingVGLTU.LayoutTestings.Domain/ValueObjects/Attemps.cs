using CSharpFunctionalExtensions;
using TestingVGLTU.SharedKernel;

namespace TestingVGLTU.LayoutTestings.Domain.ValueObjects;

public class Attemps : ValueObject
{
    private Attemps() { }
    private Attemps(int value)
    {
        Value = value;
    }

    public int Value { get; } = default!;

    public static Result<Attemps, Error> Create(int value)
    {
        if (value < 1)
            return Errors.General.ValueIsInvalid("attemps");

        var attemps = new Attemps(value);

        return attemps;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Value;
    }
}