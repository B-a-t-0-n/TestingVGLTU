using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.LayoutTestings.Domain.Entity;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.SharedKernel.ValueObjects;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class TypeTestingConfiguration : IEntityTypeConfiguration<TypeTesting>
{
    public void Configure(EntityTypeBuilder<TypeTesting> builder)
    {
        builder.ToTable("type_testings");

        builder.HasKey(i => i.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => TypeTestingId.Create(value));

        builder.ComplexProperty(p => p.Title, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasMaxLength(Title.MAX_HIGHT_TITLE_LENGTH)
                .HasColumnName("title");
        });

        builder.Property(p => p.Ratio)
                .HasColumnName("ratio");

        
    }
}
