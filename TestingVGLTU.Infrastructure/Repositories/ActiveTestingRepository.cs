using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.ActiveTestings.Application;
using TestingVGLTU.ActiveTestings.Domain.Entity;
using TestingVGLTU.Infrastructure.DbContexts;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Infrastructure.Repositories;

public class ActiveTestingRepository : IActiveTestingRepository
{
    private readonly TestingDbContext _testingDbContext;

    public ActiveTestingRepository(TestingDbContext testingDbContext)
    {
        _testingDbContext = testingDbContext;
    }

    public async Task<Guid> Add(ActiveTesting activeTesting, CancellationToken cancellationToken = default)
    {
        await _testingDbContext.ActiveTestings.AddAsync(activeTesting, cancellationToken);

        return activeTesting.Id;
    }

    public Guid Delete(ActiveTesting activeTesting, CancellationToken cancellationToken = default)
    {
        _testingDbContext.ActiveTestings.Remove(activeTesting);

        return activeTesting.Id;
    }

    public async Task<Result<ActiveTesting, Error>> GetById(ActiveTestingId id, CancellationToken cancellationToken = default)
    {
        var activeTesting = await _testingDbContext.ActiveTestings
            .Include(v => v.History)
            .ThenInclude(p => p.UserResponses)
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

        if (activeTesting is null)
            return Errors.General.NotFound(id);

        return activeTesting;
    }

    public Guid Save(ActiveTesting activeTesting, CancellationToken cancellationToken = default)
    {
        _testingDbContext.ActiveTestings.Attach(activeTesting);

        return activeTesting.Id;
    }
}
