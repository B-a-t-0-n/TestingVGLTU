using TestingVGLTU.Accounts.Application.Providers;

namespace TestingVGLTU.Infrastructure.Providers;

public class PasswordHasher : IPasswordHasherProvider
{
    public string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    public bool Verefy(string password, string heshedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, heshedPassword);
}
