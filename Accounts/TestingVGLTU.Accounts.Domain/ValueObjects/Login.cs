using CSharpFunctionalExtensions;
using TestingVGLTU.SharedKernel;

namespace TestingVGLTU.Accounts.Domain.ValueObjects;

public class Login : ValueObject
{
    private Login() { }
    private Login(string? value)
    {
        Value = value;
    }

    public string? Value { get; } = default!;

    public static Result<Login, Error> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsInvalid("login");

        if (value.Length > Constants.MAX_HIGHT_TEXT_LENGTH)
            return Errors.General.ValueIsRequired("login");

        var login = new Login(value);

        return login;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Value == null ? "" : Value;
    }
}