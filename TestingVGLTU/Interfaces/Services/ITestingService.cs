using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Services
{
    public interface ITestingService
    {
        Task<Testing?> CreateAsync(string Name, string type, string outputOfRezult, uint Attempts, int Time, int teacherId);
        Task Delete(int id);
        Task<List<Testing>> GetByTeacherId(int id);
        Task<List<TypeTesting>> GetTypeTestingAsync();
        Task<List<TypeOutputOfResult>> TypeOutputOfResultsAsync();
        Task<Testing?> GetByTestingIdFullData(int id);
        Task<Question?> GetQuestionByIdFullData(int id);
        Task Update(Testing testing);
    }
}