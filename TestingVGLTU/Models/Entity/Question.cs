﻿namespace TestingVGLTU.Models.Entity
{
    public class Question
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int Scores { get; set; }
        public Testing Testing { get; set; } = null!;
        public int TestingId { get; set; }
        public IEnumerable<UserResponsesToTests> UserResponsesToTests { get; set; } = null!;
    }
}
