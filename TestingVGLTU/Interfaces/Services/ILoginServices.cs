using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Services
{
    public interface ILoginServices
    {
        Task<User> Login(string login, string password);
        Task RegisterStudent(string name, string surname, string patronymic, string login, string password, int numberRecordBook, string groupName);
        Task RegisterTeacher(string name, string surname, string patronymic, string login, string passworв);
    }
}