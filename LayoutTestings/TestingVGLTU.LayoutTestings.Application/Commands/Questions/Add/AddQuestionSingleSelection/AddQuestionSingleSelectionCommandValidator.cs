using FluentValidation;
using TestingVGLTU.Core.Validation;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Add.AddQuestionSingleSelection;

public class AddQuestionSingleSelectionCommandValidator : AbstractValidator<AddQuestionSingleSelectionCommand>
{
    public AddQuestionSingleSelectionCommandValidator()
    {
        RuleFor(c => c.Text).MustBeValueObject(Text.Create);

        RuleFor(c => c.Scores).MustBeValueObject(Scores.Create);

        RuleFor(c => c.RightAnswer).MustBeValueObject(Answer.Create);

        RuleForEach(c => c.AnswerOptions).MustBeValueObject(Answer.Create);
    }
}
