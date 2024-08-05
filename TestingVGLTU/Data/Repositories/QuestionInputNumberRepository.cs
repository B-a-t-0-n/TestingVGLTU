using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class QuestionInputNumberRepository : IQuestionInputNumberRepository
    {
        private readonly DataContext _context;

        public QuestionInputNumberRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(string number, string text, int scores, int TestingId, double[] correctAnswers)
        {
            var group = new QuestionInputNumber()
            {
                Number = number,
                Text = text,
                Scores = scores,
                TestingId = TestingId,
                CorrectAnswers = correctAnswers
            };

            await _context.QuestionInputNumbers.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task Update(QuestionInputNumber question)
        {
            await _context.QuestionInputNumbers
                .Where(s => s.Id == question.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Number, question.Number)
                    .SetProperty(s => s.Text, question.Text)
                    .SetProperty(s => s.Scores, question.Scores)
                    .SetProperty(s => s.TestingId, question.TestingId)
                    .SetProperty(s => s.CorrectAnswers, question.CorrectAnswers)
                );
        }

        public async Task<List<QuestionInputNumber>> Get() => await _context.QuestionInputNumbers.AsNoTracking().ToListAsync();

        public async Task<QuestionInputNumber?> GetById(int id) => await _context.QuestionInputNumbers.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<List<QuestionInputNumber>> GetByTestingId(int testingId) => await _context.QuestionInputNumbers.AsNoTracking().Where(s => s.TestingId == testingId).ToListAsync();

        public async Task Delete(int id) => await _context.QuestionInputNumbers.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
