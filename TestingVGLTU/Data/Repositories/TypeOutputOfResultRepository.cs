using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class TypeOutputOfResultRepository : ITypeOutputOfResultRepository
    {
        private readonly DataContext _context;

        public TypeOutputOfResultRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(string Name)
        {
            var type = new TypeOutputOfResult()
            {
                Name = Name
            };

            await _context.TypeOutputOfResults.AddAsync(type);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TypeOutputOfResult type)
        {
            await _context.TypeOutputOfResults
                .Where(s => s.Id == type.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Name, type.Name)
                );
        }

        public async Task<List<TypeOutputOfResult>> Get() => await _context.TypeOutputOfResults.AsNoTracking().ToListAsync();

        public async Task<TypeOutputOfResult?> GetById(int id) => await _context.TypeOutputOfResults.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<TypeOutputOfResult?> GetByName(string name) => await _context.TypeOutputOfResults.AsNoTracking().Where(s => s.Name == name).FirstOrDefaultAsync();

        public async Task Delete(int id) => await _context.TypeOutputOfResults.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
