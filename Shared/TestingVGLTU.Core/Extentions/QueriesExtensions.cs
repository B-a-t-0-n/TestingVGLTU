using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingVGLTU.Core.Models;

namespace TestingVGLTU.Core.Extentions;

public static class QueriesExtensions
{
    public static async Task<PagedList<T>> ToPagedList<T>(
        this IQueryable<T> source,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var totalCount = await source.CountAsync(cancellationToken);

        var items = await source
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);

        return new PagedList<T>
        {
            Items = items,
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }

    public static async Task<PagedList<TResult>> ToPagedList<T, TResult>(
        this IQueryable<T> source,
        int page,
        int pageSize,
        Func<T, TResult> mapper,
        CancellationToken cancellationToken = default)
    {
        int totalCount = await source.CountAsync(cancellationToken);

        var items = await source
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);

        return new PagedList<TResult>
        {
            Items = items.Select(mapper).ToList(),
            PageSize = pageSize,
            Page = page,
            TotalCount = totalCount,
        };
    }

    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> query,
        bool condition,
        Expression<Func<T, bool>> predicate)
    {
        return condition ? query.Where(predicate) : query;
    }
}
