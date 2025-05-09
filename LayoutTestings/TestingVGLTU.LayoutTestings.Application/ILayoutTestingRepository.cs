using CSharpFunctionalExtensions;
using TestingVGLTU.LayoutTestings.Domain.Entity;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Application;

public interface ILayoutTestingRepository
{
    Task<Guid> Add(LayoutTesting volunteer, CancellationToken cancellationToken = default);
    Task<Result<LayoutTesting, Error>> GetById(LayoutTestingId id, CancellationToken cancellationToken = default);
    Guid Save(LayoutTesting volunteer, CancellationToken cancellationToken = default);
    Guid Delete(LayoutTesting volunteer, CancellationToken cancellationToken = default);
}
