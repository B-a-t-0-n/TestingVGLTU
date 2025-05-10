using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("questions");

        builder.HasKey(i => i.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => QuestionId.Create(value));

        builder.ComplexProperty(p => p.Scores, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasColumnName("scores");
        });

        builder.ComplexProperty(p => p.SerialNumber, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasColumnName("serial_number");
        });

        builder.ComplexProperty(p => p.Text, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasColumnName("text");
        });


        builder.HasOne(q => q.LayoutTesting)
            .WithMany(l => l.Questions)
            .HasForeignKey(q => q.LayoutTestingId);

        builder.HasOne(p => p.QuestionInputNumber)
            .WithOne()
            .HasForeignKey<QuestionInputNumber>(q => q.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.QuestionInputText)
            .WithOne()
            .HasForeignKey<QuestionInputText>(q => q.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.QuestionMultipleChoice)
            .WithOne()
            .HasForeignKey<QuestionMultipleChoice>(q => q.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.QuestionSingleSelection)
            .WithOne()
            .HasForeignKey<QuestionSingleSelection>(q => q.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.UseTptMappingStrategy();
    }
}
