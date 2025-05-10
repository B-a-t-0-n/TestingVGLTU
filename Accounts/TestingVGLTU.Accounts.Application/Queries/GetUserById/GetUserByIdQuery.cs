using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.Accounts.Application.Queries.GetUserById;

public record GetUserByIdQuery(Guid Id) : IQuery;
