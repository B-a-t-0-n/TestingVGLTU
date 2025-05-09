using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Infrastructure.DbContexts;

namespace TestingVGLTU.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly TestingDbContext _dbContext;

    public UnitOfWork(TestingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IDbTransaction> BeginTransaction(CancellationToken cancellationToken = default)
    {
        var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        return transaction.GetDbTransaction();
    }

    public async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
