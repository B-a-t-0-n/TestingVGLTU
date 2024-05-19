namespace TestingVGLTU.Data
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Student> Students { get; set; } = null!;
    }
}
