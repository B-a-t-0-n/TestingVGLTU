using CSharpFunctionalExtensions;
using TestingVGLTU.LayoutTestings.Domain.Entity;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Application;

public interface ILayoutTestingRepository
{
    Task<Guid> Add(LayoutTesting layoutTesting, CancellationToken cancellationToken = default);
    Task<Result<LayoutTesting, Error>> GetById(LayoutTestingId id, CancellationToken cancellationToken = default);
    Guid Save(LayoutTesting layoutTesting, CancellationToken cancellationToken = default);
    Guid Delete(LayoutTesting layoutTesting, CancellationToken cancellationToken = default);
}
