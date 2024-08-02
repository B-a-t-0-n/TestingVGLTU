using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class TestingRepository : ITestingRepository
    {
        private readonly DataContext _context;

        public TestingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(string name, int typeTestingId, string outputOfResult, uint attempts, DateTime time, Teacher teacher)
        {
            var testing = new Testing()
            {
                Name = name,
                TypeTestingId = typeTestingId,
                Attempts = attempts,
                Time = time,
                Teacher = teacher
                //outputOfResult
            };

            await _context.Testings.AddAsync(testing);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Testing testing)
        {
            await _context.Testings
                .Where(s => s.Id == testing.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Name, testing.Name)
                    .SetProperty(s => s.TypeTestingId, testing.TypeTestingId)
                    .SetProperty(s => s.Attempts, testing.Attempts)
                    .SetProperty(s => s.Time, testing.Time)
                );
        }

        public async Task<List<Testing>> Get() => await _context.Testings.AsNoTracking().ToListAsync();

        public async Task<List<Testing>> GetFullData() => await _context.Testings.Include(i => i.ActiveTestings).Include(i => i.Questions).AsNoTracking().ToListAsync();

        public async Task<Testing?> GetById(int id) => await _context.Testings.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<Testing?> GetFullData(int id) => await _context.Testings.Include(i => i.ActiveTestings).Include(i => i.Questions).AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task Delete(int id) => await _context.Testings.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
