namespace TestingVGLTU.Models.Entity
{
    public class TypeOutputOfResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Testing> Testings { get; set; } = null!;
    }
}
