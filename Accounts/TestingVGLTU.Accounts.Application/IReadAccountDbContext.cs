using TestingVGLTU.Accounts.Domain.Entity;

namespace TestingVGLTU.Accounts.Application;

public interface IReadAccountDbContext
{
    IQueryable<User> Users { get; }
}
