using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class QuestionMultipleChoiceRepository : IQuestionMultipleChoiceRepository
    {
        private readonly DataContext _context;

        public QuestionMultipleChoiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(string number, string text, int scores, int TestingId, string[] correctAnswers, string[] answerOptions)
        {
            var group = new QuestionMultipleChoice()
            {
                Number = number,
                Text = text,
                Scores = scores,
                TestingId = TestingId,
                CorrectAnswers = correctAnswers,
                AnswerOptions = answerOptions
            };

            await _context.QuestionMultipleChoices.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task Update(QuestionMultipleChoice question)
        {
            await _context.QuestionMultipleChoices
                .Where(s => s.Id == question.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Number, question.Number)
                    .SetProperty(s => s.Text, question.Text)
                    .SetProperty(s => s.Scores, question.Scores)
                    .SetProperty(s => s.TestingId, question.TestingId)
                    .SetProperty(s => s.CorrectAnswers, question.CorrectAnswers)
                    .SetProperty(s => s.AnswerOptions, question.AnswerOptions)
                );
        }

        public async Task<List<QuestionMultipleChoice>> Get() => await _context.QuestionMultipleChoices.AsNoTracking().ToListAsync();

        public async Task<QuestionMultipleChoice?> GetById(int id) => await _context.QuestionMultipleChoices.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<List<QuestionMultipleChoice>> GetByTestingId(int testingId) => await _context.QuestionMultipleChoices.AsNoTracking().Where(s => s.TestingId == testingId).ToListAsync();

        public async Task Delete(int id) => await _context.QuestionMultipleChoices.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
