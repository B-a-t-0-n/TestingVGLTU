namespace TestingVGLTU.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; } = null!;
        public int RoleId { get; set; }
        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
