namespace TestingVGLTU.Data.Entities
{
    public class Student : User
    {
        public int NumberRecordBook { get; set; }
        public Group Group { get; set; } = null!;
        public int GroupId { get; set; }
    }
}
