namespace TestingVGLTU.Models.Entity
{
    public class TypeTesting
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Testing> Testings { get; set; } = null!;

        public override string ToString()
        {
            return Name;
        }
    }
}