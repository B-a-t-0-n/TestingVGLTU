//using CSharpFunctionalExtensions;
//using Microsoft.Extensions.Logging;
//using TestingVGLTU.Accounts.Application.Command.Login.Command;
//using TestingVGLTU.Core.Abstractions;
//using TestingVGLTU.SharedKernel;

//namespace TestingVGLTU.Accounts.Application.Command.Login;

//public class LoginHandler : ICommandHandler<LoginResponse, LoginCommand>
//{
//    private readonly UserManager<User> _userManager;
//    private readonly ILogger<LoginHandler> _logger;
//    private readonly ITokenProvider _tokenProvider;

//    public LoginHandler(
//        UserManager<User> userManager,
//        ILogger<LoginHandler> logger,
//        ITokenProvider tokenProvider)
//    {
//        _userManager = userManager;
//        _logger = logger;
//        _tokenProvider = tokenProvider;
//    }

//    public async Task<Result<bool, ErrorList>> Login(LoginCommand command, CancellationToken cancellation = default)
//    {
//        var user = await _userManager.FindByEmailAsync(command.Email);
//        if (user == null)
//        {
//            return Errors.General.NotFound().ToErrorList();
//        }

//        var passwordValid = await _userManager.CheckPasswordAsync(user, command.Password);
//        if (!passwordValid)
//        {
//            return Errors.User.InvalidCredentials().ToErrorList();
//        }

//        var token = _tokenProvider.GenerateAccessToken(user);
//        var refrashToken = await _tokenProvider.GenerateRefreshToken(user, token.Jti, cancellation);

//        _logger.LogInformation("User logged in");

//        return new LoginResponse(token.AccessToken, refrashToken);
//    }
