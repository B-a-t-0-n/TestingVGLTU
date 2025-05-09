using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Queries.LayoutTestings.GetLayoutTestingsWithPaginationFiltration;

public record GetLayoutTestingsWithPaginationFiltrationQuery(
    Guid? TeacherId,
    string? Title,
    int? Attempts,
    Guid? TypeTestingId,
    DateTime? CreatedAt,
    DateTime? Time,
    string? TypeOutPut,
    string? SortBy,
    string? SortDirection,
    int Page,
    int PageSize) : IQuery;
