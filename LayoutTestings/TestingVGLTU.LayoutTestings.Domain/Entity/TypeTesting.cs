using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.LayoutTestings.Domain.Entity;

public class TypeTesting : SharedKernel.Entity<TypeTestingId>
{
    //EF Core
    private TypeTesting(TypeTestingId id) : base(id) { }

    private TypeTesting(
        TypeTestingId id,
        Title title,
        decimal ratio) : base(id)
    {
        Title = title;
        Ratio = ratio;
    }

    public Title Title { get; private set; } = default!;

    public decimal Ratio { get; private set; } = default!;

    public static TypeTesting Create(
        TypeTestingId id,
        Title title,
        decimal ratio)
    {
        return new TypeTesting(id, title, ratio);
    }

    public void UpdateInfo(
        Title title,
        decimal ratio)
    {
        Title = title;
        Ratio = ratio;
    }
}
