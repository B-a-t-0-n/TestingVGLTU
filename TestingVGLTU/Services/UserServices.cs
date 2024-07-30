﻿using TestingVGLTU.Interfaces;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Models;

namespace TestingVGLTU.Services
{
    public class UserServices : IUserServices
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public UserServices(IStudentRepository studentRepository, ITeacherRepository teacherRepository, IPasswordHasher passwordHasher)
        {
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task RegisterStudent(Student user)
        {
            var heshedPassword = _passwordHasher.Generate(user.Password);

            await _teacherRepository.Create(user.Name, user.Surname, user.Patronymic, user.Login, heshedPassword);
        }

        public async Task RegisterTeacher(Teacher user)
        {
            var heshedPassword = _passwordHasher.Generate(user.Password);

            await _teacherRepository.Create(user.Name, user.Surname, user.Patronymic, user.Login, heshedPassword);
        }

        public async Task<User> Login(string login, string password)
        {
            var user = await _teacherRepository.GetByLogin(login);

            if (_passwordHasher.Verefy(password, user.Password))
            {
                throw new Exception("неверный пароль");
            }

            return user;
        }
    }
}