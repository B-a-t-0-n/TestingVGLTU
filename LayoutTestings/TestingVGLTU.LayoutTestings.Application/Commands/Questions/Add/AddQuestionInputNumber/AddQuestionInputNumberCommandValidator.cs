using FluentValidation;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.Core.Validation;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Add.AddQuestionInputNumber;

public class AddQuestionInputNumberCommandValidator : AbstractValidator<AddQuestionInputNumberCommand>
{
    public AddQuestionInputNumberCommandValidator()
    {
        RuleFor(c => c.Text).MustBeValueObject(Text.Create);

        RuleFor(c => c.Scores).MustBeValueObject(Scores.Create);

        RuleForEach(c => c.CorrectAnswers).MustBeValueObject(Answer.Create);
    }
}
