using FluentValidation;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.Core.Validation;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateAnswersQuestionInputNumber;

public class UpdateAnswersQuestionInputNumberCommandValidator : AbstractValidator<UpdateAnswersQuestionInputNumberCommand>
{
    public UpdateAnswersQuestionInputNumberCommandValidator()
    {
        RuleForEach(x => x.CorrectAnswers).MustBeValueObject(Answer.Create);
    }
}
