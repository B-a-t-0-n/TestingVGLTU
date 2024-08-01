using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Data
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
        public DbSet<ActiveTesting> ActiveTesting { get; set; }
        public DbSet<UserResponsesToTests> UserResponsesToTests { get; set; }


        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().UseTptMappingStrategy();
            modelBuilder.Entity<Question>().UseTptMappingStrategy();
        }
    }
}
