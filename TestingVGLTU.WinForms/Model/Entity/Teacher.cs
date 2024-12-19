namespace TestingVGLTU.Models.Entity
{
    public class Teacher : User
    {
        public IEnumerable<Testing>? Testings { get; set; } = null!;
    }
}
