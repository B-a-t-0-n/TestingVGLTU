using TestingVGLTU.Accounts.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Accounts.Domain.Entity;

public class Student : User
{
    //EF Core
    private Student(UserId id) : base(id) { }
    public Student(
        UserId id,
        FullName name,
        Login login,
        Password passwordHash) : base(id, name, login, passwordHash)
    {
    }

    public GroupId GroupId { get; private set; } = default!;
}
