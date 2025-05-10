using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Queries.Questions.GetQuestionsWithPaginationFiltration;

public record GetQuestionsWithPaginationFiltrationQuery(
    Guid? LayoutTestingsId,
    string? Text,
    int? Scores,
    int? SerialNumber,
    string? SortBy,
    string? SortDirection,
    int Page,
    int PageSize) : IQuery;
