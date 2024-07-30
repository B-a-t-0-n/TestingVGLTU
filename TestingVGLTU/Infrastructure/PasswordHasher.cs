using TestingVGLTU.Interfaces;

namespace TestingVGLTU.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        public bool Verefy(string password, string heshedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, heshedPassword);
    }
}
