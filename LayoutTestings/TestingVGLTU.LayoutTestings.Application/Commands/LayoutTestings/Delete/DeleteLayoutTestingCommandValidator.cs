using FluentValidation;

namespace TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Delete;

public class DeleteLayoutTestingCommandValidator : AbstractValidator<DeleteLayoutTestingCommand>
{
    public DeleteLayoutTestingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}