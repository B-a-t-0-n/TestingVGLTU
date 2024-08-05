using System.ComponentModel.DataAnnotations;

namespace TestingVGLTU.Models.ViewModel
{
    public class CreateTestingViewModel
    {
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
    }
}
