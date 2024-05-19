namespace TestingVGLTU.Data
{
    public class Student
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public int NumberRecordBook { get; set; }
        public Group Group { get; set; } = null!;
        public int GroupId { get; set; }
    }
}
