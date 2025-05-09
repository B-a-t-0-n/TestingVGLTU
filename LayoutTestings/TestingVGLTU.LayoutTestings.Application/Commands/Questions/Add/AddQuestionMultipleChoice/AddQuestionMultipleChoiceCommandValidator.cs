using FluentValidation;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.Core.Validation;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Add.AddQuestionMultipleChoice;

public class AddQuestionMultipleChoiceCommandValidator : AbstractValidator<AddQuestionMultipleChoiceCommand>
{
    public AddQuestionMultipleChoiceCommandValidator()
    {
        RuleFor(c => c.Text).MustBeValueObject(Text.Create);

        RuleFor(c => c.Scores).MustBeValueObject(Scores.Create);

        RuleForEach(c => c.CorrectAnswers).MustBeValueObject(Answer.Create);

        RuleForEach(c => c.AnswerOptions).MustBeValueObject(Answer.Create);
    }
}
