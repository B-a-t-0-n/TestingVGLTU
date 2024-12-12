using BCrypt.Net;

namespace TestingVGLTU.WinForms.Providers
{
    public class PasswordHasher
    {
        public string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        public bool Verefy(string password, string heshedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, heshedPassword);
    }
}
