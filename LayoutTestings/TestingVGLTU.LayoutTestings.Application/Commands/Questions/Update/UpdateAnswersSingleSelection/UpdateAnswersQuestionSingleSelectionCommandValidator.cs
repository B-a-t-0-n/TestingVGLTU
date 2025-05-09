using FluentValidation;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.Core.Validation;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateAnswersSingleSelection;

public class UpdateAnswersQuestionSingleSelectionCommandValidator : AbstractValidator<UpdateAnswersQuestionSingleSelectionCommand>
{
    public UpdateAnswersQuestionSingleSelectionCommandValidator()
    {
        RuleForEach(x => x.AnswersOptions).MustBeValueObject(Answer.Create);

        RuleFor(x => x.RightAnswer).MustBeValueObject(Answer.Create);
    }
}
