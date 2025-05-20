using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.Core.Models;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

namespace TestingVGLTU.LayoutTestings.Application.Queries.Questions.GetQuestionsWithPaginationFiltration;

public class GetQuestionsWithPaginationFiltrationHandler 
    : IQueryHandler<PagedList<QuestionDto>, GetQuestionsWithPaginationFiltrationQuery>
{
    private readonly IReadLayoutTestingDbContext _readDbContext;
    private readonly ILogger<GetQuestionsWithPaginationFiltrationHandler> _logger;


    public GetQuestionsWithPaginationFiltrationHandler(
        IReadLayoutTestingDbContext readDbContext,
        ILogger<GetQuestionsWithPaginationFiltrationHandler> logger)
    {
        _readDbContext = readDbContext;
        _logger = logger;
    }

    public async Task<PagedList<QuestionDto>> Handle(
        GetQuestionsWithPaginationFiltrationQuery query,
        CancellationToken cancellationToken = default)
    {
        var questionsQuery = _readDbContext.Questions;

        questionsQuery = questionsQuery
            .WhereIf(
                query.LayoutTestingsId.HasValue,
                x => x.LayoutTestingId == query.LayoutTestingsId)
            .WhereIf(
                !string.IsNullOrEmpty(query.Text),
                x => x.Text.Value!.Contains(query.Text!))
            .WhereIf(
                query.Scores != null,
                x => x.Scores.Value == query.Scores)
            .WhereIf(
                query.SerialNumber != null,
                x => x.SerialNumber.Value == query.SerialNumber);

        Expression <Func<Question, object>> keySelector = query.SortBy?.ToLower() switch
        {
            "layouttestingsid" => x => x.LayoutTestingId,
            "text" => x => x.Text.Value!,
            "serialnumber" => x => x.SerialNumber,
            "scores" => x => x.Scores,
            _ => x => x.Id.Value
        };

        questionsQuery = query.SortDirection?.ToLower() switch
        {
            "asc" => questionsQuery.OrderBy(keySelector),
            "desc" => questionsQuery.OrderByDescending(keySelector),
            _ => questionsQuery
        };

        var pagedList = await questionsQuery.ToPagedList(
            query.Page,
            query.PageSize,
            x => new QuestionDto
            {
                Id = x.Id,
                Scores = x.Scores.Value,
                Text = x.Text.Value ?? "",
                SerialNumber = x.SerialNumber.Value,
                QuestionInputNumber = x.QuestionInputNumber is not null
                    ? new QuestionInputNumberDto
                    {
                        Id = x.QuestionInputNumber.Id,
                        CorrectAnswers = x.QuestionInputNumber.CorrectAnswers.Select(u => u.Value)
                    }
                    : null,
                QuestionSingleSelection = x.QuestionSingleSelection is not null
                    ? new QuestionSingleSelectionDto
                    {
                        Id = x.QuestionSingleSelection.Id,
                        AnswersOptions = x.QuestionSingleSelection.AnswerOptions.Select(u => u.Value),
                        RightAnswer = x.QuestionSingleSelection.RightAnswer.Value
                    }
                    : null,
                QuestionMultipleChoice = x.QuestionMultipleChoice is not null
                    ? new QuestionMultipleChoiceDto
                    {
                        Id = x.QuestionMultipleChoice.Id,
                        AnswersOptions = x.QuestionMultipleChoice.AnswerOptions.Select(u => u.Value),
                        CorrectAnswers = x.QuestionMultipleChoice.CorrectAnswers.Select(u => u.Value)
                    }
                    : null,
                QuestionInputText = x.QuestionInputText is not null
                    ? new QuestionInputTextDto
                    {
                        Id = x.QuestionInputText.Id,
                        CorrectAnswers = x.QuestionInputText.CorrectAnswers.Select(u => u.Value)
                    }
                    : null
            },
            cancellationToken);

        _logger.LogInformation(
            "Get Questions with pagination and filtration. Page: {Page}, PageSize: {PageSize}, TotalCount: {TotalCount}",
            query.Page,
            query.PageSize,
            pagedList.TotalCount);

        return pagedList;
    }
}