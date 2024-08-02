using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface ITestingRepository
    {
        Task Create(string name, int typeTestingId, string outputOfResult, uint attempts, DateTime time, Teacher teacher);
        Task Delete(int id);
        Task<List<Testing>> Get();
        Task<Testing?> GetById(int id);
        Task<List<Testing>> GetFullData();
        Task<Testing?> GetFullData(int id);
        Task Update(Testing testing);
    }
}