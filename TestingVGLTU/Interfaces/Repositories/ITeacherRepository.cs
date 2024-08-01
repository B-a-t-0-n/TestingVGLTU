using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface ITeacherRepository
    {
        Task Create(string Name, string Surname, string Patronymic, string Login, string Password);
        Task Delete(int id);
        Task<List<Teacher>> Get();
        Task<Teacher?> GetById(int id);
        Task<Teacher?> GetByLogin(string login);
        Task Update(Teacher teacher);
    }
}