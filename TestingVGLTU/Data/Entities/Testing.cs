﻿namespace TestingVGLTU.Data.Entities
{
    public class Testing
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TypeTestingId { get; set; }
        public TypeTesting TypeTesting { get; set; } = null!;
        public uint Attempts { get; set; }
        public DateTime Time { get; set; }
        public IEnumerable<Question> Questions { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
        public IEnumerable<ActiveTesting> ActiveTestings { get; set; } = null!;
    }
}
