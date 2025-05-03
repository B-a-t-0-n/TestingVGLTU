using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class QuestionInputTextConfiguration : IEntityTypeConfiguration<QuestionInputText>
{
    public void Configure(EntityTypeBuilder<QuestionInputText> builder)
    {
        builder.ToTable("questions_input_text");

        builder.Property(p => p.CorrectAnswers)
            .ValueObjectCollectionJsonConversion(
                answer => Answer.Create(answer.Value).Value,
                dto => Answer.Create(dto.Value).Value)
            .HasColumnName("correct_answers");
    }
}
