using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.WinForms.Data
{
    public class DataContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Testing> Testings { get; set; } = null!;
        public DbSet<TypeTesting> TypeTestings { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<QuestionMultipleChoice> QuestionMultipleChoices { get; set; } = null!;
        public DbSet<QuestionSingleSelection> QuestionSingleSelections { get; set; } = null!;
        public DbSet<QuestionInputNumber> QuestionInputNumbers { get; set; } = null!;
        public DbSet<QuestionInputText> QuestionInputText { get; set; } = null!;
        public DbSet<ActiveTesting> ActiveTesting { get; set; } = null!;
        public DbSet<UserResponsesToTests> UserResponsesToTests { get; set; } = null!;
        public DbSet<TypeOutputOfResult> TypeOutputOfResults { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestingVGLTUdb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().UseTptMappingStrategy();
            modelBuilder.Entity<Question>().UseTptMappingStrategy();

            modelBuilder.Entity<Student>().HasIndex(s => s.NumberRecordBook).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<Group>().HasIndex(g => g.Name).IsUnique();
            modelBuilder.Entity<TypeTesting>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<TypeOutputOfResult>().HasIndex(ty => ty.Name).IsUnique();

            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "ИС1-211-ОТ"},
                new Group { Id = 2, Name = "ИС1-212-ОТ" },
                new Group { Id = 3, Name = "ИС1-213-ОТ" }
            );

            modelBuilder.Entity<TypeTesting>().HasData(
                new TypeTesting { Id = 1, Name = "Олимпиада" },
                new TypeTesting { Id = 2, Name = "Тест" }
            );

            modelBuilder.Entity<TypeOutputOfResult>().HasData(
                new TypeOutputOfResult { Id = 1, Name = "По окончанию" },
                new TypeOutputOfResult { Id = 2, Name = "По завершению тестирования" }
            );
        }
    }
}
