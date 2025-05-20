using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;
using TestingVGLTU.LayoutTestings.Domain.Entity;

namespace TestingVGLTU.LayoutTestings.Application.Queries.TypeTestings.GetTypeTestingAll;

public class GetTypeTestingsAllHandler 
    : IQueryHandler<List<TypeTestingDto>, GetTypeTestingsAllQuery>
{
    private readonly IReadLayoutTestingDbContext _readDbContext;
    private readonly ILogger<GetTypeTestingsAllHandler> _logger;


    public GetTypeTestingsAllHandler(
        IReadLayoutTestingDbContext readDbContext,
        ILogger<GetTypeTestingsAllHandler> logger)
    {
        _readDbContext = readDbContext;
        _logger = logger;
    }

    public async Task<List<TypeTestingDto>> Handle(
        GetTypeTestingsAllQuery query,
        CancellationToken cancellationToken = default)
    {
        var typeTestingsQuery = _readDbContext.TypeTestings;

        Expression<Func<TypeTesting, object>> keySelector = query.SortBy?.ToLower() switch
        {
            "title" => x => x.Title.Value ?? "",
            "ratio" => x => x.Ratio,
            _ => x => x.Id.Value
        };

        typeTestingsQuery = query.SortDirection?.ToLower() switch
        {
            "asc" => typeTestingsQuery.OrderBy(keySelector),
            "desc" => typeTestingsQuery.OrderByDescending(keySelector),
            _ => typeTestingsQuery
        };

        var typeTestings = await typeTestingsQuery.ToListAsync(cancellationToken);

        var typeTestingsDto = typeTestings.Select(x => new TypeTestingDto
        {
            Id = x.Id,
            Name = x.Title.Value ?? "",
        }).ToList();

        _logger.LogInformation("Get TypeTestings all");

        return typeTestingsDto;
    }
}