namespace TestingVGLTU.Data.Entities
{
    public class UserResponsesToTests
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public ActiveTesting ActiveTesting { get; set; } = null!;
        public int ActiveTestingId { get; set; }
        public Question Question { get; set; } = null!;
        public int QuestionId { get; set; }
        public string? QuestionName { get; set; }
    }
}
