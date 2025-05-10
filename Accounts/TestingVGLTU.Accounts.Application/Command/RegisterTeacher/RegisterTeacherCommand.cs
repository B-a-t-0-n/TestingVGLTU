using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;

namespace TestingVGLTU.Accounts.Application.Command.RegisterTeacher;

public record RegisterTeacherCommand(
    string login,
    string password,
    FullNameDto FullName) : ICommand;
