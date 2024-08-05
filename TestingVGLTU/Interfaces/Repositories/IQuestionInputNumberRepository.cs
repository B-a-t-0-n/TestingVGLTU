using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface IQuestionInputNumberRepository
    {
        Task Create(string number, string text, int scores, int TestingId, double[] correctAnswers);
        Task Delete(int id);
        Task<List<QuestionInputNumber>> Get();
        Task<QuestionInputNumber?> GetById(int id);
        Task<List<QuestionInputNumber>> GetByTestingId(int testingId);
        Task Update(QuestionInputNumber question);
    }
}