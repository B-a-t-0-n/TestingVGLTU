using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface IUserResponsesToTestsRepository
    {
        Task Create(int studentId, int questionId, int activeTestingId, string answer);
        Task Delete(int id);
        Task<List<UserResponsesToTests>> Get();
        Task<List<UserResponsesToTests>> GetByActiveTestingId(int id);
        Task<List<UserResponsesToTests>> GetByActiveTestingIdAndStudentId(int studentId, int activeTestingId);
        Task<UserResponsesToTests?> GetById(int id);
        Task<List<UserResponsesToTests>> GetByStudenId(int id);
        Task Update(UserResponsesToTests testing);
    }
}