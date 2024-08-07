﻿using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task Create(string Name, string Surname, string Patronymic, string Login, string Password, int NumberRecordBook, int groupId);
        Task Delete(int id);
        Task<List<Student>> Get();
        Task<Student?> GetById(int id);
        Task<Student?> GetByLogin(string login);
        Task<List<Student>> GetWithGroup();
        Task Update(Student student);
    }
}