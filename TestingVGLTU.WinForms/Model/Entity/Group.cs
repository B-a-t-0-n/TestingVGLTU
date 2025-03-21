﻿namespace TestingVGLTU.Models.Entity
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Student> Students { get; set; } = null!;
        public IEnumerable<ActiveTesting> ActiveTestings { get; set; } = null!;

        public override string ToString()
        {
            return Name;
        }
    }
}
