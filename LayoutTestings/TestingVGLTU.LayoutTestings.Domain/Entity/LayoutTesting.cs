using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity;

public class LayoutTesting : SharedKernel.Entity<LayoutTestingId>
{
    //EF core
    private LayoutTesting(LayoutTestingId id) : base(id) { }

    private LayoutTesting(
        LayoutTestingId id,
        Title title,
        Attemps attemps, 
        TypeTestingId typeTestingId,
        DateTime time, 
        TeacherId teacherId,
        DateTime createdAt,
        TypeOutPut typeOutPut) : base(id)
    {
        Title = title;
        Attemps = attemps;
        TypeTestingId = typeTestingId;
        Time = time;
        TeacherId = teacherId;
        CreatedAt = createdAt;
        TypeOutPut = typeOutPut;
    }

    public Title Title { get; set; } = default!;

    public Attemps Attemps { get; set; } = default!;

    public TypeTestingId TypeTestingId { get; set; } = default!;

    public DateTime Time { get; set; }

    public TeacherId TeacherId { get; set; } = default!;

    public DateTime CreatedAt { get; set; }

    public TypeOutPut TypeOutPut { get; set; } = default!;

    public static LayoutTesting Create(
        LayoutTestingId id,
        Title title,
        Attemps attemps,
        TypeTestingId typeTestingId,
        DateTime time,
        TeacherId teacherId,
        DateTime createdAt,
        TypeOutPut typeOutPut)
    {
        return new LayoutTesting(id, title, attemps, typeTestingId, time, teacherId, createdAt, typeOutPut);
    }
}
