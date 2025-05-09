using FluentValidation;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.Core.Validation;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateAnswerQuestionMultipleChoice;

public class UpdateAnswerQuestionMultipleChoiceCommandValidator : AbstractValidator<UpdateAnswerQuestionMultipleChoiceCommand>
{
    public UpdateAnswerQuestionMultipleChoiceCommandValidator()
    {
        RuleForEach(x => x.CorrectAnswers).MustBeValueObject(Answer.Create);
        RuleForEach(x => x.AnswersOptions).MustBeValueObject(Answer.Create);
    }
}
