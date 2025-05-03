using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.LayoutTestings.Domain.Entity;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.SharedKernel.ValueObjects;
using TestingVGLTU.Accounts.Domain.Entity;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class LayoutTestingConfiguration : IEntityTypeConfiguration<LayoutTesting>
{
    public void Configure(EntityTypeBuilder<LayoutTesting> builder)
    {
        builder.ToTable("layouts_testings");

        builder.HasKey(i => i.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => LayoutTestingId.Create(value));

        builder.ComplexProperty(p => p.Title, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasMaxLength(Title.MAX_HIGHT_TITLE_LENGTH)
                .HasColumnName("title");
        });

        builder.ComplexProperty(p => p.Attemps, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasColumnName("attemps");
        });

        builder.ComplexProperty(p => p.TypeOutPut, pb =>
        {
            pb.Property(n => n.Value)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("type_out_put");
        });

        builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at");

        builder.Property(p => p.Time)
                .HasColumnName("time");

        builder.HasMany(v => v.Questions)
            .WithOne()
            .IsRequired()
            .HasForeignKey("layout_testing_id");

        builder.HasOne(v => v.TypeTesting)
            .WithMany()
            .IsRequired()
            .HasForeignKey(v => v.TypeTestingId);

        builder.HasOne<Teacher>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(v => v.TeacherId);

        builder.Property(p => p.TeacherId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }
}
