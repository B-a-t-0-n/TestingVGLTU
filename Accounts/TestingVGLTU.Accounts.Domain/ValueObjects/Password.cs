using CSharpFunctionalExtensions;
using TestingVGLTU.SharedKernel;

namespace TestingVGLTU.Accounts.Domain.ValueObjects;

public class Password : ValueObject
{
    private Password() { }
    private Password(string? value)
    {
        Value = value;
    }

    public string? Value { get; } = default!;

    public static Result<Password, Error> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsInvalid("password");

        if (value.Length > Constants.MAX_HIGHT_TEXT_LENGTH)
            return Errors.General.ValueIsRequired("password");

        var password = new Password(value);

        return password;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Value == null ? "" : Value;
    }
}
