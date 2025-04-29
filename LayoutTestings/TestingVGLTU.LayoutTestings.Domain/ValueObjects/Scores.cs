using CSharpFunctionalExtensions;
using TestingVGLTU.SharedKernel;

namespace TestingVGLTU.LayoutTestings.Domain.ValueObjects;

public class Scores : ValueObject
{
    private Scores() { }
    private Scores(int value)
    {
        Value = value;
    }

    public int Value { get; } = default!;

    public static Result<Scores, Error> Create(int value)
    {
        if (value < 1)
            return Errors.General.ValueIsInvalid("scores");

        var attemps = new Scores(value);

        return attemps;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Value;
    }
}