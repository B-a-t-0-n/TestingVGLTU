using TestingVGLTU.ActiveTestings.Domain.Entity;

namespace TestingVGLTU.ActiveTestings.Application;

public interface IReadActiveTestingDbContext
{
    IQueryable<ActiveTesting> ActiveTestings { get; }

    IQueryable<History> Histories { get; }

    IQueryable<UserResponse> UserResponses { get; }
}
