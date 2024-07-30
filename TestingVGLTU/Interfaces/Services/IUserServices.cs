using TestingVGLTU.Models;

namespace TestingVGLTU.Interfaces.Services
{
    public interface IUserServices
    {
        Task<User> Login(string login, string password);
        Task RegisterStudent(Student user);
        Task RegisterTeacher(Teacher user);
    }
}