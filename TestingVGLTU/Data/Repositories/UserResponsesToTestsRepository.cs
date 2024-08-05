using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class UserResponsesToTestsRepository : IUserResponsesToTestsRepository
    {
        private readonly DataContext _context;

        public UserResponsesToTestsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(int studentId, int questionId, int activeTestingId, string answer)
        {
            var testing = new UserResponsesToTests()
            {
                StudentId = studentId,
                QuestionId = questionId,
                ActiveTestingId = activeTestingId,
                QuestionName = answer
            };

            await _context.UserResponsesToTests.AddAsync(testing);
            await _context.SaveChangesAsync();
        }

        public async Task Update(UserResponsesToTests testing)
        {
            await _context.UserResponsesToTests
                .Where(s => s.Id == testing.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.StudentId, testing.StudentId)
                    .SetProperty(s => s.QuestionId, testing.QuestionId)
                    .SetProperty(s => s.ActiveTestingId, testing.ActiveTestingId)
                    .SetProperty(s => s.QuestionName, testing.QuestionName)
                );
        }

        public async Task<List<UserResponsesToTests>> Get() => await _context.UserResponsesToTests.AsNoTracking().ToListAsync();

        public async Task<UserResponsesToTests?> GetById(int id) => await _context.UserResponsesToTests.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<List<UserResponsesToTests>> GetByStudenId(int id) => await _context.UserResponsesToTests.Include(i => i.Student).AsNoTracking().Where(s => s.StudentId == id).ToListAsync();

        public async Task<List<UserResponsesToTests>> GetByActiveTestingId(int id) => await _context.UserResponsesToTests.Include(i => i.ActiveTesting).AsNoTracking().Where(s => s.ActiveTestingId == id).ToListAsync();

        public async Task<List<UserResponsesToTests>> GetByActiveTestingIdAndStudentId(int studentId, int activeTestingId) =>
            await _context.UserResponsesToTests.Include(i => i.ActiveTesting)
                                               .Include(i => i.Student)
                                               .AsNoTracking().Where(s => s.ActiveTestingId == activeTestingId && s.StudentId == studentId).ToListAsync();

        public async Task Delete(int id) => await _context.ActiveTesting.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
