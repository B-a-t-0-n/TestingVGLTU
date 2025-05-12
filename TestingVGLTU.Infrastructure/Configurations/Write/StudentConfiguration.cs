using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");
    }
}
