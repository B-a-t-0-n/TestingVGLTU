namespace TestingVGLTU.Accounts.Application.Providers;

public interface IPasswordHasherProvider
{
    string Generate(string password);
    bool Verefy(string password, string heshedPassword);
}
