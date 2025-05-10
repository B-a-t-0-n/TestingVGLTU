using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.Accounts.Application.Queries.GerUserWithPagination;

public record GetUserWithPaginationQuery(
    string? SortBy,
    string? SortDirection,
    int Page,
    int PageSize) : IQuery;
