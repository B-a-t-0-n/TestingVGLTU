using System.ComponentModel.DataAnnotations;

namespace TestingVGLTU.Models.ViewModel;

public class RegistrationViewModel
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Patronymic { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;

    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string PasswordCopy { get; set; } = null!;

    public int? NumberRecordBook { get; set; }

    public string? Group { get; set; }

    public bool IsTeacher { get; set; } = false;
}
