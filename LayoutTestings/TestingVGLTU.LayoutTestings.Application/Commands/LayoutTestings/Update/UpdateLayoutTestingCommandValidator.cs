using FluentValidation;
using TestingVGLTU.Core.Validation;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Update;

public class UpdateLayoutTestingCommandValidator : AbstractValidator<UpdateLayoutTestingCommand>
{
    public UpdateLayoutTestingCommandValidator()
    {
        RuleFor(c => c.Title).MustBeValueObject(Title.Create);

        RuleFor(c => c.Attemps).MustBeValueObject(Attemps.Create);

        RuleFor(c => c.TypeOutPut).MustBeValueObject(TypeOutPut.Create);
    }
}