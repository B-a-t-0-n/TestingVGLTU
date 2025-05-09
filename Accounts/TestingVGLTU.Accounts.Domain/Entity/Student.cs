using TestingVGLTU.Accounts.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Accounts.Domain.Entity;

public class Student : User
{
    //EF Core
    private Student(UserId id) : base(id) { }
    internal Student(
        UserId id,
        FullName name,
        Login login,
        Password passwordHash,
        GroupId groupId) : base(id, name, login, passwordHash)
    {
        GroupId = groupId;
    }

    public GroupId GroupId { get; private set; } = default!;
}
