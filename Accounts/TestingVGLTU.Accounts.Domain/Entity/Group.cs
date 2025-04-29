using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Accounts.Domain.Entity;

public class Group : SharedKernel.Entity<GroupId>
{
    private List<Student> _students = [];

    //EF Core
    private Group(GroupId id) : base(id) { }
    public Group(
        GroupId id,
        Title name) : base(id)
    {
        Name = name;
    }

    public Title Name { get; set; } = default!;

    public IReadOnlyList<Student> Students => _students;
}
