namespace TestingVGLTU.Interfaces
{
    public interface IPasswordHasher
    {
        string Generate(string password);
        bool Verefy(string password, string heshedPassword);
    }
}