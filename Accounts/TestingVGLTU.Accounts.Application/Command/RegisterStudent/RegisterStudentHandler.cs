using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.Accounts.Application.Providers;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.Accounts.Domain.ValueObjects;

namespace TestingVGLTU.Accounts.Application.Command.RegisterStudent;

public class RegisterStudentHandler : ICommandHandler<Guid, RegisterStudentCommand>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<RegisterStudentHandler> _logger;
    private readonly IValidator<RegisterStudentCommand> _validator;
    private readonly IPasswordHasherProvider _passwordHasherProvider;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterStudentHandler(
        IAccountRepository accountRepository,
        ILogger<RegisterStudentHandler> logger,
        IValidator<RegisterStudentCommand> validator,
        IPasswordHasherProvider passwordHasherProvider, 
        IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _logger = logger;
        _validator = validator;
        _passwordHasherProvider = passwordHasherProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid, ErrorList>> Handle(RegisterStudentCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToErrorList();
        }

        var userExists = await _accountRepository.GetByLogin(command.login, cancellationToken);
        if (userExists.IsSuccess)
        {
            return Errors.General.AlreadyExist().ToErrorList();
        }

        var userId = UserId.NewId();

        var loginResult = Domain.ValueObjects.Login.Create(command.login);
        if (loginResult.IsFailure)
            return loginResult.Error.ToErrorList();

        var fullNameResult = FullName.Create(
            command.FullName.Name,
            command.FullName.Surname,
            command.FullName.Patronymic);
        if (fullNameResult.IsFailure)
            return fullNameResult.Error.ToErrorList();

        var groupId = GroupId.Create(command.GroupId);

        var passwordHashed = Password.Create(_passwordHasherProvider.Generate(command.password));
        if (passwordHashed.IsFailure)
            return passwordHashed.Error.ToErrorList();

        var user = User.CreateStudent(
            userId,
            fullNameResult.Value,
            loginResult.Value,
            passwordHashed.Value,
            groupId);

        await _accountRepository.Add(user, cancellationToken);

        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("register student with id {userId}", user.Id);

        return user.Id.Value;
    }
}
