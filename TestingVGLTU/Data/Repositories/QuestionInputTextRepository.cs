using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class QuestionInputTextRepository
    {
        private readonly DataContext _context;

        public QuestionInputTextRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(string number, string text, int scores, int TestingId, string[] correctAnswers)
        {
            var group = new QuestionInputText()
            {
                Number = number,
                Text = text,
                Scores = scores,
                TestingId = TestingId,
                CorrectAnswers = correctAnswers
            };

            await _context.QuestionInputText.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task Update(QuestionInputText question)
        {
            await _context.QuestionInputText
                .Where(s => s.Id == question.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Number, question.Number)
                    .SetProperty(s => s.Text, question.Text)
                    .SetProperty(s => s.Scores, question.Scores)
                    .SetProperty(s => s.TestingId, question.TestingId)
                    .SetProperty(s => s.CorrectAnswers, question.CorrectAnswers)
                );
        }

        public async Task<List<QuestionInputText>> Get() => await _context.QuestionInputText.AsNoTracking().ToListAsync();

        public async Task<QuestionInputText?> GetById(int id) => await _context.QuestionInputText.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<List<QuestionInputText>> GetByTestingId(int testingId) => await _context.QuestionInputText.AsNoTracking().Where(s => s.TestingId == testingId).ToListAsync();

        public async Task Delete(int id) => await _context.QuestionInputText.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
