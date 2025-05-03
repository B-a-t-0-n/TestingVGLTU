using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("groups");

        builder.HasKey(i => i.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => GroupId.Create(value));

        builder.ComplexProperty(p => p.Name, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasMaxLength(Title.MAX_HIGHT_TITLE_LENGTH)
                .HasColumnName("name");
        });

        builder.HasMany(v => v.Students)
           .WithOne()
           .IsRequired()
           .HasForeignKey(v => v.GroupId);
    }
}