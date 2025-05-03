using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;
using TestingVGLTU.Core.Extentions;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class QuestionMultipleChoiceConfiguration : IEntityTypeConfiguration<QuestionMultipleChoice>
{
    public void Configure(EntityTypeBuilder<QuestionMultipleChoice> builder)
    {
        builder.ToTable("question_multiple_choice");

        builder.Property(p => p.CorrectAnswers)
            .ValueObjectCollectionJsonConversion(
                answer => Answer.Create(answer.Value).Value,
                dto => Answer.Create(dto.Value).Value)
            .HasColumnName("correct_answers");

        builder.Property(p => p.AnswerOptions)
            .ValueObjectCollectionJsonConversion(
                answer => Answer.Create(answer.Value).Value,
                dto => Answer.Create(dto.Value).Value)
            .HasColumnName("answer_options");
    }
}