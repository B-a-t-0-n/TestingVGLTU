using Microsoft.Extensions.Logging;
using PetFamily.Core.Models;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;
using TestingVGLTU.Core.Extentions;

namespace TestingVGLTU.LayoutTestings.Application.Queries.TypeTestings.GetTypeTestingWithPagination;

public class GetTypeTestingsWithPaginationHandler 
    : IQueryHandler<PagedList<TypeTestingDto>, GetTypeTestingsWithPaginationQuery>
{
    private readonly IReadLayoutTestingDbContext _readDbContext;
    private readonly ILogger<GetTypeTestingsWithPaginationHandler> _logger;


    public GetTypeTestingsWithPaginationHandler(
        IReadLayoutTestingDbContext readDbContext,
        ILogger<GetTypeTestingsWithPaginationHandler> logger)
    {
        _readDbContext = readDbContext;
        _logger = logger;
    }

    public async Task<PagedList<TypeTestingDto>> Handle(
        GetTypeTestingsWithPaginationQuery query,
        CancellationToken cancellationToken = default)
    {
        var typeTestingQueryQuery = _readDbContext.TypeTestings;

        var pagedList = await typeTestingQueryQuery.ToPagedList(
            query.Page,
            query.PageSize,
            d => new TypeTestingDto 
            {
                Id = d.Id,
                Name = d.Title.Value!,
            },
            cancellationToken);

        _logger.LogInformation("Get TypeTestings with pagination {Page} {PageSize}", query.Page, query.PageSize);

        return pagedList;
    }
}