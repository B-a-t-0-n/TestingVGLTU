namespace TestingVGLTU.Data.Entities
{
    public class Teacher : User
    {
        public IEnumerable<Testing> Testings { get; set; } = null!;
    }
}
