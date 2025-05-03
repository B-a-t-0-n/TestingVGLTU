using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class QuestionSingleSelectionConfiguration : IEntityTypeConfiguration<QuestionSingleSelection>
{
    public void Configure(EntityTypeBuilder<QuestionSingleSelection> builder)
    {
        builder.ToTable("questions_single_selection");

        builder.Property(p => p.AnswerOptions)
            .ValueObjectCollectionJsonConversion(
                answer => Answer.Create(answer.Value).Value,
                dto => Answer.Create(dto.Value).Value)
            .HasColumnName("answer_options");

        builder.ComplexProperty(p => p.RightAnswer, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasColumnName("right_answer");
        });
    }
}
