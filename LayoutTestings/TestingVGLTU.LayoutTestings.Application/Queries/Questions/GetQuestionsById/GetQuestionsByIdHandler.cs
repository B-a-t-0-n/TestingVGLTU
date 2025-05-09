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
        //var question = await _readDbContext.Questions
        //    .Include(q => q)
        //    .Include(q => q.QuestionInputNumber)
        //    .Include(q => q.QuestionInputMultipleChoice)
        //    .Include(q => q.QuestionInputSingleSelection)
        //    .FirstOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        //_logger.LogInformation("Get question by id {Id}", query.Id);

        return null!;
    }
}