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

        public async Task<Testing?> Create(string name, string typeTesting, string outputOfResult, uint attempts, TimeOnly time, int teacherId)
        {
            var type = await _context.TypeTestings.FirstOrDefaultAsync(i => i.Name == typeTesting);
            var output = await _context.TypeOutputOfResults.FirstOrDefaultAsync(i => i.Name == outputOfResult);

            var testing = new Testing()
            {
                Name = name,
                TypeTestingId = type!.Id,
                Attempts = attempts,
                Time = time,
                TeacherId = teacherId,
                TimeCreate = DateTime.Now,
                TypeOutputOfResultId = output!.Id
            };

            await _context.Testings.AddAsync(testing);
            await _context.SaveChangesAsync();

            return await _context.Testings.FirstOrDefaultAsync(t => t.TimeCreate == testing.TimeCreate && t.TeacherId == testing.TeacherId);
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

        public async Task<List<Testing>> GetFullData() => await _context.Testings.Include(i => i.ActiveTestings).Include(i => i.Questions)
                                                                                 .Include(i => i.TypeTesting).Include(i => i.TypeOutputOfResult)
                                                                                 .AsNoTracking().ToListAsync();

        public async Task<Testing?> GetById(int id) => await _context.Testings.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<List<Testing>> GetByTeacherId(int id) => await _context.Testings.Include(i => i.TypeTesting).Include(i => i.TypeOutputOfResult)
                                                                                          .Include(i => i.Teacher).Where(i => i.TeacherId == id)
                                                                                          .AsNoTracking().ToListAsync();

        public async Task<Testing?> GetFullData(int id) => await _context.Testings.Include(i => i.ActiveTestings).Include(i => i.Questions)
                                                                                  .Include(i => i.TypeTesting).Include(i => i.TypeOutputOfResult)
                                                                                  .AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task Delete(int id) => await _context.Testings.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
