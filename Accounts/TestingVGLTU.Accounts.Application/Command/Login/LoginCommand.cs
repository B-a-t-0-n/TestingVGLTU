using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.Accounts.Application.Command.Login;

public record LoginCommand(string login, string password) : ICommand;
