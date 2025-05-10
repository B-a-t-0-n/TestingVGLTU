using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;

namespace TestingVGLTU.LayoutTestings.Application.Queries.Questions.GetQuestionsById;
public class GetQuestionsByIdHandler : IQueryHandler<QuestionDto?, GetQuestionsByIdQuery>
{
    private readonly IReadLayoutTestingDbContext _readDbContext;
    private readonly ILogger<GetQuestionsByIdHandler> _logger;


    public GetQuestionsByIdHandler(
        IReadLayoutTestingDbContext readDbContext,
        ILogger<GetQuestionsByIdHandler> logger)
    {
        _readDbContext = readDbContext;
        _logger = logger;
    }

    public async Task<QuestionDto?> Handle(
        GetQuestionsByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var question = await _readDbContext.Questions
            .Include(q => q.QuestionInputText)
            .Include(q => q.QuestionInputNumber)
            .Include(q => q.QuestionMultipleChoice)
            .Include(q => q.QuestionSingleSelection)
            .FirstOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        _logger.LogInformation("Get question by id {Id}", query.Id);

        if (question is null)
            return null;

        QuestionMultipleChoiceDto? questionMultipleChoiceDto = null; 
        if (question.QuestionMultipleChoice is not null)
        {
            questionMultipleChoiceDto = new QuestionMultipleChoiceDto
            {
                Id = question.QuestionMultipleChoice.Id,
                AnswersOptions = question.QuestionMultipleChoice.AnswerOptions.Select(u => u.Value),
                CorrectAnswers = question.QuestionMultipleChoice.CorrectAnswers.Select(u => u.Value)
            };
        }

        QuestionInputNumberDto? questionInputNumberDto = null;
        if (question.QuestionInputNumber is not null)
        {
            questionInputNumberDto = new QuestionInputNumberDto
            {
                Id = question.QuestionInputNumber.Id,
                CorrectAnswers = question.QuestionInputNumber.CorrectAnswers.Select(u => u.Value),
            };
        }

        QuestionInputTextDto? questionInputTextDto = null;
        if (question.QuestionInputText is not null)
        {
            questionInputTextDto = new QuestionInputTextDto
            {
                Id = question.QuestionInputText.Id,
                CorrectAnswers = question.QuestionInputText.CorrectAnswers.Select(u => u.Value),
            };
        }

        QuestionSingleSelectionDto? questionSingleSelectionDto = null;
        if (question.QuestionSingleSelection is not null) 
        {
            questionSingleSelectionDto = new QuestionSingleSelectionDto
            {
                Id = question.QuestionSingleSelection.Id,
                AnswersOptions = question.QuestionSingleSelection.AnswerOptions.Select(q => q.Value),
                RightAnswer = question.QuestionSingleSelection.RightAnswer.Value
            };
        }

        var questionDto = new QuestionDto
        {
            Id = question.Id,
            Text = question.Text.Value ?? "",
            Scores = question.Scores.Value,
            SerialNumber = question.SerialNumber.Value,
            QuestionMultipleChoice = questionMultipleChoiceDto,
            QuestionInputNumber = questionInputNumberDto,
            QuestionSingleSelection = questionSingleSelectionDto,
            QuestionInputText = questionInputTextDto
        };

        return questionDto;
    }
}