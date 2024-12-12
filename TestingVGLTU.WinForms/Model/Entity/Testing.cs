namespace TestingVGLTU.Models.Entity
{
    public class Testing
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TypeTestingId { get; set; }
        public TypeTesting TypeTesting { get; set; } = null!;
        public uint Attempts { get; set; }
        public TimeOnly Time { get; set; }
        public IEnumerable<Question> Questions { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
        public int TeacherId { get; set; }
        public IEnumerable<ActiveTesting> ActiveTestings { get; set; } = null!;
        public DateTime TimeCreate { get; set; }
        public TypeOutputOfResult TypeOutputOfResult { get; set; } = null!;
        public int TypeOutputOfResultId { get; set; }
        public int? ScoresFor5 { get; set; }
        public int? ScoresFor4 { get; set; }
        public int? ScoresFor3 { get; set; }
    }
}
