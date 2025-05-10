using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;

namespace TestingVGLTU.Accounts.Application.Command.RegisterStudent;

public record RegisterStudentCommand(
    string login,
    string password,
    FullNameDto FullName,
    Guid GroupId) : ICommand;
