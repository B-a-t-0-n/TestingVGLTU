using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Services
{
    public interface ITestingService
    {
        Task<Testing?> Create(string Name, string type, string outputOfRezult, uint Attempts, int Time, int teacherId);
        Task Update(Testing testing);
    }
}