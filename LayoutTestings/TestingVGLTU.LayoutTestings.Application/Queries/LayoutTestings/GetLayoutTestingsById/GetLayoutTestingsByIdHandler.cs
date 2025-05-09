using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;

namespace TestingVGLTU.LayoutTestings.Application.Queries.LayoutTestings.GetLayoutTestingsById;

public class GetLayoutTestingsByIdHandler : IQueryHandler<LayoutTestingDto?, GetLayoutTestingsByIdQuery>
{
    private readonly IReadLayoutTestingDbContext _readDbContext;
    private readonly ILogger<GetLayoutTestingsByIdHandler> _logger;


    public GetLayoutTestingsByIdHandler(
        IReadLayoutTestingDbContext readDbContext,
        ILogger<GetLayoutTestingsByIdHandler> logger)
    {
        _readDbContext = readDbContext;
        _logger = logger;
    }

    public async Task<LayoutTestingDto?> Handle(
        GetLayoutTestingsByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var layoutTesting = await _readDbContext.LayoutTestings.FirstOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        _logger.LogInformation("Get LayoutTesting by id {Id}", query.Id);

        if (layoutTesting is null)
            return null;

        var layoutTestingDto = new LayoutTestingDto
        {
            Id = layoutTesting.Id,
            TeacherId = layoutTesting.TeacherId,
            Title = layoutTesting.Title.Value!,
            Attemps = layoutTesting.Attemps.Value,
            TypeTestingId = layoutTesting.TypeTestingId,
            CreatedAt = layoutTesting.CreatedAt,
            Time = layoutTesting.Time,
            TypeOutPut = layoutTesting.TypeOutPut.Value,
        };

        return layoutTestingDto;
    }
}