using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingVGLTU.SharedKernel.ValueObjects.IDs;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.SharedKernel;

namespace TestingVGLTU.Infrastructure.Configurations.Write;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(i => i.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.ComplexProperty(v => v.FullName, fnb =>
        {
            fnb.Property(f => f.Surname)
                .IsRequired(true)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("surname");

            fnb.Property(f => f.FirstName)
                .IsRequired(true)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("name");

            fnb.Property(f => f.Patronymic)
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("patronymic");
        });

        builder.ComplexProperty(p => p.Password, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("password");
        });

        builder.ComplexProperty(p => p.Login, pb =>
        {
            pb.IsRequired();

            pb.Property(n => n.Value)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("Login");
        });

        builder.HasOne(p => p.Student)
            .WithOne()
            .HasForeignKey<Student>(q => q.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Teacher)
            .WithOne()
            .HasForeignKey<Teacher>(q => q.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.UseTptMappingStrategy();
    }
}