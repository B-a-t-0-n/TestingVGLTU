namespace TestingVGLTU.Core.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    
    public StudentDto? Student { get; set; }
    public TeacherDto? Teacher { get; set; }
}