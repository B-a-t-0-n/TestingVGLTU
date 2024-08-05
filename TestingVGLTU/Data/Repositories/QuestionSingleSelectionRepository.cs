using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class QuestionSingleSelectionRepository : IQuestionSingleSelectionRepository
    {
        private readonly DataContext _context;

        public QuestionSingleSelectionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(string number, string text, int scores, int TestingId, string rightAnswer, string[] answerOptions)
        {
            var group = new QuestionSingleSelection()
            {
                Number = number,
                Text = text,
                Scores = scores,
                TestingId = TestingId,
                RightAnswer = rightAnswer,
                AnswerOptions = answerOptions
            };

            await _context.QuestionSingleSelections.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task Update(QuestionSingleSelection question)
        {
            await _context.QuestionSingleSelections
                .Where(s => s.Id == question.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Number, question.Number)
                    .SetProperty(s => s.Text, question.Text)
                    .SetProperty(s => s.Scores, question.Scores)
                    .SetProperty(s => s.TestingId, question.TestingId)
                    .SetProperty(s => s.RightAnswer, question.RightAnswer)
                    .SetProperty(s => s.AnswerOptions, question.AnswerOptions)
                );
        }

        public async Task<List<QuestionSingleSelection>> Get() => await _context.QuestionSingleSelections.AsNoTracking().ToListAsync();

        public async Task<QuestionSingleSelection?> GetById(int id) => await _context.QuestionSingleSelections.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<List<QuestionSingleSelection>> GetByTestingId(int testingId) => await _context.QuestionSingleSelections.AsNoTracking().Where(s => s.TestingId == testingId).ToListAsync();

        public async Task Delete(int id) => await _context.QuestionSingleSelections.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
