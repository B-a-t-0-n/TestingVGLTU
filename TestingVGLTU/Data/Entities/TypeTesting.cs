namespace TestingVGLTU.Data.Entities
{
    public class TypeTesting
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Testing> Testings { get; set; } = null!;
    }
}