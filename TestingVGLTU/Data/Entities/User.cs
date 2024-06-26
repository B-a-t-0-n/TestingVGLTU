﻿namespace TestingVGLTU.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public IEnumerable<UserResponsesToTests> UserResponsesToTests { get; set; } = null!;
    }
}
