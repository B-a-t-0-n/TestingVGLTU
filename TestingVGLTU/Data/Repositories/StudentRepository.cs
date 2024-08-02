using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(string Name, string Surname, string Patronymic, string Login, string Password, int NumberRecordBook, int groupId)
        {
            var student = new Student()
            {
                Name = Name,
                Surname = Surname,
                Patronymic = Patronymic,
                Login = Login,
                Password = Password,
                NumberRecordBook = NumberRecordBook,
                GroupId = groupId
            };

            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            await _context.Students
                .Where(s => s.Id == student.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Name, student.Name)
                    .SetProperty(s => s.Surname, student.Surname)
                    .SetProperty(s => s.Patronymic, student.Patronymic)
                    .SetProperty(s => s.Login, student.Login)
                    .SetProperty(s => s.Password, student.Password)
                    .SetProperty(s => s.NumberRecordBook, student.NumberRecordBook)
                    .SetProperty(s => s.Group, student.Group));
        }

        public async Task SetGroup(Student student)
        {
            await _context.Students
                .Where(s => s.Id == student.Id)
                .ExecuteUpdateAsync(i => i
                    .SetProperty(s => s.Name, student.Name)
                    .SetProperty(s => s.Surname, student.Surname)
                    .SetProperty(s => s.Patronymic, student.Patronymic)
                    .SetProperty(s => s.Login, student.Login)
                    .SetProperty(s => s.Password, student.Password)
                    .SetProperty(s => s.NumberRecordBook, student.NumberRecordBook)
                    .SetProperty(s => s.Group, student.Group));
        }

        public async Task<List<Student>> Get() => await _context.Students.AsNoTracking().ToListAsync();

        public async Task<List<Student>> GetWithGroup() => await _context.Students.AsNoTracking().Include(s => s.Group).ToListAsync();

        public async Task<Student?> GetById(int id) => await _context.Students.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<Student?> GetByLogin(string login) => await _context.Students.AsNoTracking().Where(s => s.Login == login).FirstOrDefaultAsync();
          
        public async Task Delete(int id) => await _context.Students.Where(s => s.Id == id).ExecuteDeleteAsync();
    }
}
