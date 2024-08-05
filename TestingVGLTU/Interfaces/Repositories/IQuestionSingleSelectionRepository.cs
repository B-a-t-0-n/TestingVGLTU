using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface IQuestionSingleSelectionRepository
    {
        Task Create(string number, string text, int scores, int TestingId, string rightAnswer, string[] answerOptions);
        Task Delete(int id);
        Task<List<QuestionSingleSelection>> Get();
        Task<QuestionSingleSelection?> GetById(int id);
        Task<List<QuestionSingleSelection>> GetByTestingId(int testingId);
        Task Update(QuestionSingleSelection question);
    }
}