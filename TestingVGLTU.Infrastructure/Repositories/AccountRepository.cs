using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Accounts.Application;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.Infrastructure.DbContexts;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly TestingDbContext _testingDbContext;
    public AccountRepository(TestingDbContext testingDbContext)
    {
        _testingDbContext = testingDbContext;
    }
    public async Task<Guid> Add(User user, CancellationToken cancellationToken = default)
    {
        await _testingDbContext.Users.AddAsync(user, cancellationToken);
        return user.Id;
    }

    public Guid Delete(User user, CancellationToken cancellationToken = default)
    {
        _testingDbContext.Users.Remove(user);

        return user.Id;
    }

    public async Task<Result<User, Error>> GetById(UserId id, CancellationToken cancellationToken = default)
    {
        var user = await _testingDbContext.Users
            .Include(u => u.Student)
            .Include(u => u.Teacher)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (user is null)
            return Errors.General.NotFound(id);

        return user;
    }

    public async Task<Result<User, Error>> GetByLogin(string login, CancellationToken cancellationToken = default)
    {
        var user = await _testingDbContext.Users
                .Include(u => u.Student)
                .Include(u => u.Teacher)
                .FirstOrDefaultAsync(p => p.Login.Value!.ToLower() == login.ToLower(), cancellationToken);

        if (user is null)
            return Errors.General.NotFound(login);

        return user;
    }

    public Guid Save(User user, CancellationToken cancellationToken = default)
    {
        _testingDbContext.Users.Attach(user);

        return user.Id;
    }
}
