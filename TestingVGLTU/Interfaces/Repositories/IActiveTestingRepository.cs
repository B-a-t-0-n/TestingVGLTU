using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface IActiveTestingRepository
    {
        Task Create(int groupId, int testingId, DateTime datePublication);
        Task Delete(int id);
        Task<List<ActiveTesting>> Get();
        Task<ActiveTesting?> GetById(int id);
        Task<List<ActiveTesting>> GetByTestingId(int id);
        Task Update(ActiveTesting testing);
    }
}