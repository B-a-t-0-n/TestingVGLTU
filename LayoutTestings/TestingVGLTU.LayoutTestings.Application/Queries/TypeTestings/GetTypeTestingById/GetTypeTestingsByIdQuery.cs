using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Queries.TypeTestings.GetTypeTestingById;

public record GetTypeTestingsByIdQuery(Guid Id) : IQuery;
