using CSharpFunctionalExtensions;
using TestingVGLTU.ActiveTestings.Domain.Entity;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.ActiveTestings.Application;

public interface IActiveTestingRepository
{
    Task<Guid> Add(ActiveTesting activeTesting, CancellationToken cancellationToken = default);
    Task<Result<ActiveTesting, Error>> GetById(ActiveTestingId id, CancellationToken cancellationToken = default);
    Guid Save(ActiveTesting activeTesting, CancellationToken cancellationToken = default);
    Guid Delete(ActiveTesting activeTesting, CancellationToken cancellationToken = default);
}
