using FluentValidation;
using TestingVGLTU.Core.Validation;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateQuestionMainInfo;

public class UpdateQuestionMainInfoCommandValidator : AbstractValidator<UpdateQuestionMainInfoCommand>
{
    public UpdateQuestionMainInfoCommandValidator()
    {
        RuleFor(c => c.Text).MustBeValueObject(Text.Create);

        RuleFor(c => c.Scores).MustBeValueObject(Scores.Create);
    }
}
