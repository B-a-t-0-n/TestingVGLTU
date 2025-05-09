using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Queries.LayoutTestings.GetLayoutTestingsById;

public record GetLayoutTestingsByIdQuery(Guid Id) : IQuery;
