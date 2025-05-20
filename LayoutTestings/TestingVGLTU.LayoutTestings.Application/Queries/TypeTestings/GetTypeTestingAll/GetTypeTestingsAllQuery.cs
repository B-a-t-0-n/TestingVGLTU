using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Queries.TypeTestings.GetTypeTestingAll;

public record GetTypeTestingsAllQuery(
    string? SortBy,
    string? SortDirection) : IQuery;
