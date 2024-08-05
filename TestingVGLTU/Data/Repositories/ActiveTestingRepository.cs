using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class ActiveTestingRepository
    {
        private readonly DataContext _context;

        public ActiveTestingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(int groupId, int testingId, DateTime datePublication)
        {
            var testing = new ActiveTesting()
            {
                GroupId = groupId,
                TestingId = testingId,
                DatePublication = datePublication,
            };

            await _context.ActiveTesting.AddAsync(testing);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ActiveTesting testing)
        {
            await _context.ActiveTesting
                .Where(s => s.Id == testing.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.GroupId, testing.GroupId)
                    .SetProperty(s => s.TestingId, testing.TestingId)
                    .SetProperty(s => s.DatePublication, testing.DatePublication)
                );
        }

        public async Task<List<ActiveTesting>> Get() => await _context.ActiveTesting.AsNoTracking().ToListAsync();

        public async Task<ActiveTesting?> GetById(int id) => await _context.ActiveTesting.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<List<ActiveTesting>> GetByTestingId(int id) => await _context.ActiveTesting.Include(i => i.Testing).AsNoTracking().Where(s => s.TestingId == id).ToListAsync();

        public async Task Delete(int id) => await _context.ActiveTesting.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
