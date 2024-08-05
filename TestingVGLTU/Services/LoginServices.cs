using TestingVGLTU.Interfaces;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IGroupRepository _groupRepository;

        public LoginServices(IStudentRepository studentRepository, ITeacherRepository teacherRepository, IPasswordHasher passwordHasher, IGroupRepository groupRepository)
        {
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _passwordHasher = passwordHasher;
            _groupRepository = groupRepository;
        }

        public async Task RegisterStudent(string name, string surname, string patronymic, string login, string password, int numberRecordBook, string groupName)
        {
            var group = await _groupRepository.GetByName(groupName);

            if (group == null)
                throw new Exception("группа не найдена");

            var heshedPassword = _passwordHasher.Generate(password);

            await _studentRepository.Create(name, surname, patronymic, login, heshedPassword, numberRecordBook, group!.Id);
        }

        public async Task RegisterTeacher(string name, string surname, string patronymic, string login, string password)
        {
            var heshedPassword = _passwordHasher.Generate(password);

            await _teacherRepository.Create(name, surname, patronymic, login, heshedPassword);
        }

        public async Task<User> Login(string login, string password)
        {
            var userTeacher = await _teacherRepository.GetByLogin(login);
            var userStudent = await _studentRepository.GetByLogin(login);

            User? activeUser = userTeacher == null ? userStudent : userTeacher;

            if (activeUser == null)
            {
                throw new Exception("неверный логин");
            }

            if (!_passwordHasher.Verefy(password, activeUser!.Password))
            {
                throw new Exception("неверный пароль");
            }

            return activeUser;
        }
    }
}
