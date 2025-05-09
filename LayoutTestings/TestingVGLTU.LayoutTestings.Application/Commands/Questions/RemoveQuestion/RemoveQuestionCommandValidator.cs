using FluentValidation;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.RemoveQuestion;

public class RemoveQuestionCommandValidator : AbstractValidator<RemoveQuestionCommand>
{
    public RemoveQuestionCommandValidator()
    {
        RuleFor(x => x.LayoutTestingId).NotEmpty();

        RuleFor(x => x.QuestionId).NotEmpty();
    }
}
