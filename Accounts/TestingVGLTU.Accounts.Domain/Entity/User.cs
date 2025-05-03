using TestingVGLTU.Accounts.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Accounts.Domain.Entity;

public class User : SharedKernel.Entity<UserId>
{
    //EF Core
    protected User(UserId id) : base(id) { }

    protected User(
        UserId id,
        FullName name,
        Login login,
        Password password) : base(id)
    {
        Name = name;
        Login = login;
        Password = password;
    }

    public FullName Name { get; private set; } = default!;
    public Login Login { get; private set; } = default!;
    public Password Password { get; private set; } = default!;

    public static User Create(UserId id, FullName fullName, Login login, Password password)
    {
        return new User(id, fullName, login, password);
    }
}
