using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.ActiveTestings.Domain.Entity;
using TestingVGLTU.SharedKernel;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class UserResponseConfiguration : IEntityTypeConfiguration<UserResponse>
{
    public void Configure(EntityTypeBuilder<UserResponse> builder)
    {
        builder.ToTable("user_response");

        builder.HasKey(i => i.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => UserResponseId.Create(value));

        builder.Property(p => p.IsCorrect)
            .HasColumnName("is_correct");

        builder.Property(p => p.Response)
            .HasMaxLength(Constants.MAX_HIGHT_TEXT_LENGTH)
            .HasColumnName("response");

        builder.HasOne<Question>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(v => v.QuestionId);
    }
}