using CSharpFunctionalExtensions;

namespace TestingVGLTU.SharedKernel.ValueObjects;

public class Title : ValueObject
{
    public const int MAX_HIGHT_TITLE_LENGTH = 100;

    private Title() { }
    private Title(string? value)
    {
        Value = value;
    }

    public string? Value { get; } = default!;

    public static Result<Title, Error> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsInvalid("title");

        if (value.Length > MAX_HIGHT_TITLE_LENGTH)
            return Errors.General.ValueIsRequired("title");

        var title = new Title(value);

        return title;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Value == null ? "" : Value;
    }
}
