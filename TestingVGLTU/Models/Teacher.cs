namespace TestingVGLTU.Models
{
    public class Teacher : User
    {
        public IEnumerable<Testing> Testings { get; set; } = null!;
    }
}
