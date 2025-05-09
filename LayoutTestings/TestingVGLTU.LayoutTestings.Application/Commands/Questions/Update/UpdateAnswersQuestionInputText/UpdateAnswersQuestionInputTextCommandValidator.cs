using FluentValidation;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.Core.Validation;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateAnswersQuestionInputText;

public class UpdateAnswersQuestionInputTextCommandValidator : AbstractValidator<UpdateAnswersQuestionInputTextCommand>
{
    public UpdateAnswersQuestionInputTextCommandValidator()
    {
        RuleForEach(x => x.CorrectAnswers).MustBeValueObject(Answer.Create);
    }
}
