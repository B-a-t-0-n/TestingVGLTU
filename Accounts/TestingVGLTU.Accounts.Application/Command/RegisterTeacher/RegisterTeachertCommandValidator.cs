using TestingVGLTU.Core.Validation;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.Accounts.Application.Command.RegisterTeacher;

public class RegisterTeachertCommandValidator : FluentValidation.AbstractValidator<RegisterTeacherCommand>
{
    public RegisterTeachertCommandValidator()
    {
        RuleFor(x => x.login).MustBeValueObject(Domain.ValueObjects.Login.Create);
        RuleFor(x => x.FullName).MustBeValueObject(x => FullName.Create(x.Name, x.Surname, x.Patronymic));

    }
}
