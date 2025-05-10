using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.Accounts.Application.Providers;

namespace TestingVGLTU.Accounts.Application.Command.Login;

public class LoginHandler : ICommandHandler<User, LoginCommand>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<LoginHandler> _logger;
    private readonly IValidator<LoginCommand> _validator;
    private readonly IPasswordHasherProvider _passwordHasherProvider;

    public LoginHandler(
        IAccountRepository accountRepository,
        ILogger<LoginHandler> logger,
        IValidator<LoginCommand> validator,
        IPasswordHasherProvider passwordHasherProvider)
    {
        _accountRepository = accountRepository;
        _logger = logger;
        _validator = validator;
        _passwordHasherProvider = passwordHasherProvider;
    }

    public async Task<Result<User, ErrorList>> Handle(LoginCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToErrorList();
        }

        var userResult = await _accountRepository.GetByLogin(command.login);
        if (userResult.IsFailure)
            return userResult.Error.ToErrorList();

        if (_passwordHasherProvider.Verefy(command.password, userResult.Value.Password.Value ?? "") == false)
            return Errors.General.NotFound().ToErrorList();

        _logger.LogInformation("login user with id {userId}", userResult.Value.Id);

        return userResult.Value;
    }
}
