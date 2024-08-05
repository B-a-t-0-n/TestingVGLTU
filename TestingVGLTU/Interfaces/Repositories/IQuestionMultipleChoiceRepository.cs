using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface IQuestionMultipleChoiceRepository
    {
        Task Create(string number, string text, int scores, int TestingId, string[] correctAnswers, string[] answerOptions);
        Task Delete(int id);
        Task<List<QuestionMultipleChoice>> Get();
        Task<QuestionMultipleChoice?> GetById(int id);
        Task<List<QuestionMultipleChoice>> GetByTestingId(int testingId);
        Task Update(QuestionMultipleChoice question);
    }
}