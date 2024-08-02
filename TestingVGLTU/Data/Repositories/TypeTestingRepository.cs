using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class TypeTestingRepository : ITypeTestingRepository
    {
        private readonly DataContext _context;

        public TypeTestingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(string Name)
        {
            var type = new TypeTesting()
            {
                Name = Name
            };

            await _context.TypeTestings.AddAsync(type);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TypeTesting type)
        {
            await _context.TypeTestings
                .Where(s => s.Id == type.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Name, type.Name)
                );
        }

        public async Task<List<TypeTesting>> Get() => await _context.TypeTestings.AsNoTracking().ToListAsync();

        public async Task<TypeTesting?> GetById(int id) => await _context.TypeTestings.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<TypeTesting?> GetByName(string name) => await _context.TypeTestings.AsNoTracking().Where(s => s.Name == name).FirstOrDefaultAsync();

        public async Task Delete(int id) => await _context.TypeTestings.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
