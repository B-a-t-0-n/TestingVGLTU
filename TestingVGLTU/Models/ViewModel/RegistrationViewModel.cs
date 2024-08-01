using System.ComponentModel.DataAnnotations;

namespace TestingVGLTU.Models.ViewModel
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "*обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "*обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия должна быть от 2 до 50 символов")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "*обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Отчество должно быть от 2 до 50 символов")]
        public string Patronymic { get; set; } = null!;

        [Required(ErrorMessage = "*обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Логин должен быть от 2 до 50 символов")]
        public string Login { get; set; } = null!;

        [Required(ErrorMessage = "*обязательно")]
        [StringLength(24, MinimumLength = 8, ErrorMessage = "Пароль должен быть от 8 до 24 символов")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordCopy { get; set; } = null!;

        public int? NumberRecordBook { get; set; }

        public string? Group { get; set; }

        public bool IsTeacher { get; set; } = false;
    }
}
