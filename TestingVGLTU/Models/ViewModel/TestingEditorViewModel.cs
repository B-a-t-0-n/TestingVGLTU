using System.ComponentModel.DataAnnotations;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Models.ViewModel
{
    public class TestingEditorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Название должено быть от 2 до 50 символов")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "*обязательно")]
        public string Type { get; set; } = null!;

        [Required(ErrorMessage = "*обязательно")]
        public string OutputOfResult { get; set; } = null!;

        [Required(ErrorMessage = "*обязательно")]
        public uint Attempts { get; set; }

        [Required(ErrorMessage = "*обязательно")]
        public int Time { get; set; }

        public List<string>? TypeTesting { get; set; }

        public List<string>? TypeOutputOfResult { get; set; }

        public int? ScoresFor5 { get; set; }

        public int? ScoresFor4 { get; set; }

        public int? ScoresFor3 { get; set; }

        public List<Group> Groups { get; set; } = null!;

        public List<Question> Question { get; set; } = null!;
    }
}
