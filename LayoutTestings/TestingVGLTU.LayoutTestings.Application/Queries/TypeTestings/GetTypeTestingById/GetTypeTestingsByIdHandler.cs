using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;

namespace TestingVGLTU.LayoutTestings.Application.Queries.TypeTestings.GetTypeTestingById;

public class GetTypeTestingsByIdHandler : IQueryHandler<TypeTestingDto?, GetTypeTestingsByIdQuery>
{
    private readonly IReadLayoutTestingDbContext _readDbContext;
    private readonly ILogger<GetTypeTestingsByIdHandler> _logger;


    public GetTypeTestingsByIdHandler(
        IReadLayoutTestingDbContext readDbContext,
        ILogger<GetTypeTestingsByIdHandler> logger)
    {
        _readDbContext = readDbContext;
        _logger = logger;
    }

    public async Task<TypeTestingDto?> Handle(
        GetTypeTestingsByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var typeTesting = await _readDbContext.TypeTestings.FirstOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        _logger.LogInformation("Get TypeTestings by id {Id}", query.Id);

        return typeTesting is null ? null : new TypeTestingDto 
        {
            Id = typeTesting.Id,
            Name = typeTesting.Title.Value!,
        };
    }
}