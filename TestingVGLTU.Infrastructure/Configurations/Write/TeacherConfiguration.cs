using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("teachers");
    }
}
