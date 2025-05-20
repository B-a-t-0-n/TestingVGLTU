using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.Core.Models;
using TestingVGLTU.LayoutTestings.Domain.Entity;

namespace TestingVGLTU.LayoutTestings.Application.Queries.LayoutTestings.GetLayoutTestingsWithPaginationFiltration;

public class GetLayoutTestingsWithPaginationFiltrationHandler 
    : IQueryHandler<PagedList<LayoutTestingDto>, GetLayoutTestingsWithPaginationFiltrationQuery>
{
    private readonly IReadLayoutTestingDbContext _readDbContext;
    private readonly ILogger<GetLayoutTestingsWithPaginationFiltrationHandler> _logger;


    public GetLayoutTestingsWithPaginationFiltrationHandler(
        IReadLayoutTestingDbContext readDbContext,
        ILogger<GetLayoutTestingsWithPaginationFiltrationHandler> logger)
    {
        _readDbContext = readDbContext;
        _logger = logger;
    }

    public async Task<PagedList<LayoutTestingDto>> Handle(
        GetLayoutTestingsWithPaginationFiltrationQuery query,
        CancellationToken cancellationToken = default)
    {
        var layoutTestingQueryQuery = _readDbContext.LayoutTestings;

        layoutTestingQueryQuery = layoutTestingQueryQuery
            .WhereIf(
                query.TeacherId.HasValue,
                x => x.TeacherId == query.TeacherId)
            .WhereIf(
                !string.IsNullOrEmpty(query.Title),
                x => x.Title.Value!.Contains(query.Title!))
            .WhereIf(
                query.Attempts != null,
                x => x.Attemps.Value == query.Attempts)
            .WhereIf(
                query.TypeTestingId != null,
                x => x.TypeTestingId == query.TypeTestingId)
            .WhereIf(
                query.CreatedAt != null,
                x => x.CreatedAt == query.CreatedAt)
            .WhereIf(
                query.Time != null,
                x => x.Time == query.Time)
            .WhereIf(
                !string.IsNullOrEmpty(query.TypeOutPut),
                x => x.TypeOutPut.Value.Contains(query.TypeOutPut!));

        Expression <Func<LayoutTesting, object>> keySelector = query.SortBy?.ToLower() switch
        {
            "teacherid" => x => x.TeacherId.Value,
            "title" => x => x.Title.Value!,
            "createdat" => x => x.CreatedAt,
            "time" => x => x.Time,
            "typeoutput" => x => x.TypeOutPut.Value,
            "attempts" => x => x.Attemps.Value,
            "typetestingid" => x => x.TypeTestingId.Value,
            _ => x => x.Id.Value
        };

        layoutTestingQueryQuery = query.SortDirection?.ToLower() switch
        {
            "asc" => layoutTestingQueryQuery.OrderBy(keySelector),
            "desc" => layoutTestingQueryQuery.OrderByDescending(keySelector),
            _ => layoutTestingQueryQuery
        };

        var pagedList = await layoutTestingQueryQuery.ToPagedList(
            query.Page,
            query.PageSize,
            x => new LayoutTestingDto
            {
                Id = x.Id,
                TeacherId = x.TeacherId,
                Title = x.Title.Value!,
                Attemps = x.Attemps.Value,
                TypeTestingId = x.TypeTestingId,
                CreatedAt = x.CreatedAt,
                Time = x.Time,
                TypeOutPut = x.TypeOutPut.Value,
            },
            cancellationToken);

        _logger.LogInformation(
            "Get LayoutTestings with pagination and filtration. Page: {Page}, PageSize: {PageSize}, TotalCount: {TotalCount}",
            query.Page,
            query.PageSize,
            pagedList.TotalCount);

        return pagedList;
    }
}