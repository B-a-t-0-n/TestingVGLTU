namespace TestingVGLTU.Models.Entity
{
    public class UserResponsesToTests
    {
        public int Id { get; set; }
        public Student? Student { get; set; }
        public int? StudentId { get; set; }
        public ActiveTesting? ActiveTesting { get; set; }
        public int? ActiveTestingId { get; set; }
        public Question? Question { get; set; }
        public int? QuestionId { get; set; }
        public string? QuestionName { get; set; }
    }
}
