using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Application.Commands.Questions.Update.UpdateQuestionMainInfo;

public class UpdateQuestionMainInfoHandler : ICommandHandler<Guid, UpdateQuestionMainInfoCommand>
{
    private readonly ILayoutTestingRepository _volunteerRepository;
    private readonly ILogger<UpdateQuestionMainInfoHandler> _logger;
    private readonly IValidator<UpdateQuestionMainInfoCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateQuestionMainInfoHandler(
        ILayoutTestingRepository volunteerRepository,
        ILogger<UpdateQuestionMainInfoHandler> logger,
        IValidator<UpdateQuestionMainInfoCommand> validator,
        [FromKeyedServices(Modules.LayoutTestings)] IUnitOfWork unitOfWork)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<Guid, ErrorList>> Handle(UpdateQuestionMainInfoCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToErrorList();
        }

        var layoutTestingId = LayoutTestingId.Create(command.LayoutTestingId);

        var questionId = QuestionId.Create(command.QuestionId);

        var layoutTestingResult = await _volunteerRepository.GetById(layoutTestingId, cancellationToken);
        if (layoutTestingResult.IsFailure)
            return layoutTestingResult.Error.ToErrorList();

        var text = Text.Create(command.Text);
        if (text.IsFailure)
            return text.Error.ToErrorList();

        var scores = Scores.Create(command.Scores);
        if (scores.IsFailure)
            return scores.Error.ToErrorList();

        var result = layoutTestingResult.Value.UpdateMainInfoQuestion(
            questionId,
            text.Value,
            scores.Value);
        if (result.IsFailure)
            return result.Error.ToErrorList();

        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("Question with id {QuestionId} updated", questionId.Value);

        return questionId.Value;
    }
}
