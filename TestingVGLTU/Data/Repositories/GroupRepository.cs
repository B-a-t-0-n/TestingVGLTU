using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using TestingVGLTU.Data;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;

        public GroupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(string Name)
        {
            var group = new Group()
            {
                Name = Name
            };

            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Group group)
        {
            await _context.Groups
                .Where(s => s.Id == group.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Name, group.Name)
                );
        }

        public async Task<List<Group>> Get() => await _context.Groups.AsNoTracking().ToListAsync();

        public async Task<Group?> GetById(int id) => await _context.Groups.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<Group?> GetByName(string name) => await _context.Groups.AsNoTracking().Where(s => s.Name == name).FirstOrDefaultAsync();

        public async Task Delete(int id) => await _context.Groups.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
