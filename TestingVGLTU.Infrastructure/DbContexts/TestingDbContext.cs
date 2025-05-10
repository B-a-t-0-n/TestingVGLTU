using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.ActiveTestings.Domain.Entity;
using TestingVGLTU.LayoutTestings.Domain.Entity;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

namespace TestingVGLTU.Infrastructure.DbContexts;

public class TestingDbContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<LayoutTesting> LayoutTestings => Set<LayoutTesting>();

    public DbSet<TypeTesting> TypeTestings => Set<TypeTesting>();

    public DbSet<Question> Questions => Set<Question>();

    public DbSet<User> Users => Set<User>();

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Teacher> Teachers => Set<Teacher>();

    public DbSet<Group> Groups => Set<Group>();

    public DbSet<ActiveTesting> ActiveTestings => Set<ActiveTesting>();

    public DbSet<History> Histories => Set<History>();

    public DbSet<UserResponse> UserResponses => Set<UserResponse>();

    public TestingDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TestingVGLTU");

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TestingDbContext).Assembly,
            type => type.FullName?.Contains("Configurations.Write") ?? false);
    }
}
