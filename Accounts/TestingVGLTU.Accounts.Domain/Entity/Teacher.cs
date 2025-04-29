using TestingVGLTU.Accounts.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Accounts.Domain.Entity;

public class Teacher : User
{
    //EF Core
    private Teacher(UserId id) : base(id) { }
    public Teacher(
        UserId id,
        FullName name,
        Login login,
        Password passwordHash) : base(id, name, login, passwordHash)
    {
    }
}