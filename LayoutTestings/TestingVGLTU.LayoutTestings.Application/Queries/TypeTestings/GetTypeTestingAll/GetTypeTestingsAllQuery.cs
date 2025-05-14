using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Queries.TypeTestings.GetTypeTestingWithPagination;

public record GetTypeTestingsAllQuery(
    string? SortBy,
    string? SortDirection) : IQuery;
