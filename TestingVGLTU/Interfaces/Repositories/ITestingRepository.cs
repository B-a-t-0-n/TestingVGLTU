using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface ITestingRepository
    {
        Task<Testing?> Create(string name, string typeTesting, string outputOfResult, uint attempts, DateTime time, int teacherId);
        Task Delete(int id);
        Task<List<Testing>> Get();
        Task<Testing?> GetById(int id);
        Task<List<Testing>> GetFullData();
        Task<Testing?> GetFullData(int id);
        Task Update(Testing testing);
    }
}