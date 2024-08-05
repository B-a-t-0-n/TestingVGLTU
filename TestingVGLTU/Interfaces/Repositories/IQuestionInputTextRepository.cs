using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface IQuestionInputTextRepository
    {
        Task Create(string number, string text, int scores, int TestingId, string[] correctAnswers);
        Task Delete(int id);
        Task<List<QuestionInputText>> Get();
        Task<QuestionInputText?> GetById(int id);
        Task<List<QuestionInputText>> GetByTestingId(int testingId);
        Task Update(QuestionInputText question);
    }
}