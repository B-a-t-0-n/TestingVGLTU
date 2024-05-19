namespace TestingVGLTU.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public IEnumerable<Testing> Testings { get; set; } = null!;
    }
}
