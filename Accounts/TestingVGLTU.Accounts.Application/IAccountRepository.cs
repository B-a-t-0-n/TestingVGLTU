using CSharpFunctionalExtensions;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Accounts.Application;

public interface IAccountRepository
{
    Task<Guid> Add(User user, CancellationToken cancellationToken = default);
    Task<Result<User, Error>> GetById(UserId id, CancellationToken cancellationToken = default);
    Task<Result<User, Error>> GetByLogin(string login, CancellationToken cancellationToken = default);
    Guid Save(User user, CancellationToken cancellationToken = default);
    Guid Delete(User user, CancellationToken cancellationToken = default);
}

