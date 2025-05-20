using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.ActiveTestings.Domain.Entity;
using TestingVGLTU.LayoutTestings.Domain.Entity;
using TestingVGLTU.Core.Extentions;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class ActiveTestingConfiguration : IEntityTypeConfiguration<ActiveTesting>
{
    public void Configure(EntityTypeBuilder<ActiveTesting> builder)
    {
        builder.ToTable("active_testing");

        builder.HasKey(i => i.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => ActiveTestingId.Create(value));


        builder.Property(p => p.IsComplite)
            .HasColumnName("is_complite");

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at");

        builder.Property(p => p.EndDate)
            .IsRequired(false)
            .HasColumnName("end_date");

        builder.HasMany(v => v.History)
           .WithOne()
           .IsRequired()
           .HasForeignKey(v => v.ActiveTestingId);

        builder.Property(p => p.GroupsId)
            .ValueObjectCollectionJsonConversion(
                group => GroupId.Create(group.Value).Value,
                GroupId.Create)
            .HasColumnName("groups_id");

        builder.HasOne<LayoutTesting>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(v => v.LayoutTestingId);
    }
}
