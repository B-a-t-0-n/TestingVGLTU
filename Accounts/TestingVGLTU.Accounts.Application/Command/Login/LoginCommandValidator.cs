using TestingVGLTU.Core.Validation;

namespace TestingVGLTU.Accounts.Application.Command.Login;

public class LoginCommandValidator : FluentValidation.AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.login).MustBeValueObject(Domain.ValueObjects.Login.Create);
        RuleFor(x => x.password).MustBeValueObject(Domain.ValueObjects.Password.Create);
    }
}
