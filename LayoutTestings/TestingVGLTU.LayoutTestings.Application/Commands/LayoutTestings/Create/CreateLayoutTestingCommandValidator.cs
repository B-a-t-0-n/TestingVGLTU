using FluentValidation;
using TestingVGLTU.Core.Validation;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Create;

public class CreateLayoutTestingCommandValidator : AbstractValidator<CreateLayoutTestingCommand>
{
    public CreateLayoutTestingCommandValidator()
    {
        RuleFor(c => c.Title).MustBeValueObject(Title.Create);

        RuleFor(c => c.Attemps).MustBeValueObject(Attemps.Create);

        RuleFor(c => c.TypeOutPut).MustBeValueObject(TypeOutPut.Create);
    }
}