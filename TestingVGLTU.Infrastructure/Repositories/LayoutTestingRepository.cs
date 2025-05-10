using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Infrastructure.DbContexts;
using TestingVGLTU.LayoutTestings.Application;
using TestingVGLTU.LayoutTestings.Domain.Entity;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Infrastructure.Repositories;

public class LayoutTestingRepository : ILayoutTestingRepository
{
    private readonly TestingDbContext _testingDbContext;

    public LayoutTestingRepository(TestingDbContext testingDbContext)
    {
        _testingDbContext = testingDbContext;
    }

    public async Task<Guid> Add(LayoutTesting layoutTesting, CancellationToken cancellationToken = default)
    {
        await _testingDbContext.LayoutTestings.AddAsync(layoutTesting, cancellationToken);

        return layoutTesting.Id;
    }

    public Guid Delete(LayoutTesting layoutTesting, CancellationToken cancellationToken = default)
    {
        _testingDbContext.LayoutTestings.Remove(layoutTesting);

        return layoutTesting.Id;
    }

    public async Task<Result<LayoutTesting, Error>> GetById(LayoutTestingId id, CancellationToken cancellationToken = default)
    {
        var layoutTesting = await _testingDbContext.LayoutTestings
             .Include(v => v.TypeTesting)
             .Include(v => v.Questions)
             .ThenInclude(p => p.QuestionInputNumber)
             .ThenInclude(p => p.QuestionInputText)
             .ThenInclude(p => p.QuestionMultipleChoice)
             .ThenInclude(p => p.QuestionSingleSelection)
             .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

        if (layoutTesting is null)
            return Errors.General.NotFound(id);

        return layoutTesting;
    }

    public Guid Save(LayoutTesting layoutTesting, CancellationToken cancellationToken = default)
    {
        _testingDbContext.LayoutTestings.Attach(layoutTesting);

        return layoutTesting.Id;
    }
}
