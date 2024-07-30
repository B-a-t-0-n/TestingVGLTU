using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Models;

namespace TestingVGLTU.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(string Name, string Surname, string Patronymic, string Login, string Password)
        {
            var teacher = new Teacher()
            {
                Name = Name,
                Surname = Surname,
                Patronymic = Patronymic,
                Login = Login,
                Password = Password,
            };

            await _context.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Teacher teacher)
        {
            await _context.Teachers
                .Where(s => s.Id == teacher.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Name, teacher.Name)
                    .SetProperty(s => s.Surname, teacher.Surname)
                    .SetProperty(s => s.Patronymic, teacher.Patronymic)
                    .SetProperty(s => s.Login, teacher.Login)
                    .SetProperty(s => s.Password, teacher.Password)
                    );
        }

        public async Task<List<Teacher>> Get() => await _context.Teachers.AsNoTracking().ToListAsync();

        public async Task<Teacher> GetById(int id) => await _context.Teachers.AsNoTracking().Where(s => s.Id == id).FirstAsync();

        public async Task<Teacher> GetByLogin(string login) => await _context.Teachers.AsNoTracking().Where(s => s.Login == login).FirstAsync();

        public async Task Delete(int id) => await _context.Students.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
