using TestingVGLTU.Core.Validation;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.Accounts.Application.Command.RegisterStudent;

public class RegisterStudentCommandValidator : FluentValidation.AbstractValidator<RegisterStudentCommand>
{
    public RegisterStudentCommandValidator()
    {
        RuleFor(x => x.login).MustBeValueObject(Domain.ValueObjects.Login.Create);
        RuleFor(x => x.FullName).MustBeValueObject(x => FullName.Create(x.Name, x.Surname, x.Patronymic));
    }
}
