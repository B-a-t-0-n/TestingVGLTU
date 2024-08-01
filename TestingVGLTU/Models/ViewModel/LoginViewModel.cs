using System.ComponentModel.DataAnnotations;

namespace TestingVGLTU.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Логин должен быть от 2 до 50 символов")]
        public string Login { get; set; } = null!;
        [Required(ErrorMessage = "*обязательно")]
        [StringLength(24, MinimumLength = 8, ErrorMessage = "Пароль должен быть от 8 до 24 символов")]
        public string Password { get; set; } = null!;
    }
}
