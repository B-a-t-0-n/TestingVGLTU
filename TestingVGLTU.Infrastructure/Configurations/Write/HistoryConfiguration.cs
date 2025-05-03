using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.ActiveTestings.Domain.Entity;
using TestingVGLTU.Accounts.Domain.Entity;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class HistoryConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
    {
        builder.ToTable("history");

        builder.HasKey(i => i.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => HistoryId.Create(value));

        builder.ComplexProperty(p => p.Attemp, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasColumnName("attemp");
        });

        builder.Property(p => p.IsComplite)
            .HasColumnName("is_complite");

        builder.Property(p => p.Time)
            .HasColumnName("time");

        builder.HasMany(v => v.UserResponses)
           .WithOne()
           .IsRequired()
           .HasForeignKey(v => v.HistoryId);

        builder.HasOne<Student>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(v => v.StudentId);

        builder.Property(p => p.StudentId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }
}
