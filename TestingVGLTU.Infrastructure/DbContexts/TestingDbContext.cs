using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Accounts.Application;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.ActiveTestings.Application;
using TestingVGLTU.ActiveTestings.Domain.Entity;
using TestingVGLTU.LayoutTestings.Application;
using TestingVGLTU.LayoutTestings.Domain.Entity;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

namespace TestingVGLTU.Infrastructure.DbContexts;

public class TestingDbContext : DbContext, IReadLayoutTestingDbContext, IReadAccountDbContext, IReadActiveTestingDbContext
{
    private readonly string _connectionString;

    public DbSet<LayoutTesting> LayoutTestings => Set<LayoutTesting>();

    public DbSet<TypeTesting> TypeTestings => Set<TypeTesting>();

    public DbSet<Question> Questions => Set<Question>();

    public DbSet<User> Users => Set<User>();

    public DbSet<Group> Groups => Set<Group>();

    public DbSet<ActiveTesting> ActiveTestings => Set<ActiveTesting>();

    public DbSet<History> Histories => Set<History>();

    public DbSet<UserResponse> UserResponses => Set<UserResponse>();

    IQueryable<LayoutTesting> IReadLayoutTestingDbContext.LayoutTestings => LayoutTestings;

    IQueryable<Question> IReadLayoutTestingDbContext.Questions => Questions;

    IQueryable<TypeTesting> IReadLayoutTestingDbContext.TypeTestings => TypeTestings;

    IQueryable<User> IReadAccountDbContext.Users => Users;

    IQueryable<ActiveTesting> IReadActiveTestingDbContext.ActiveTestings => ActiveTestings;

    IQueryable<History> IReadActiveTestingDbContext.Histories => Histories;

    IQueryable<UserResponse> IReadActiveTestingDbContext.UserResponses => UserResponses;

    public TestingDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseLoggerFactory(CreateLogerFactory());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TestingVGLTU");

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TestingDbContext).Assembly,
            type => type.FullName?.Contains("Configurations.Write") ?? false);

        
    }

    private ILoggerFactory CreateLogerFactory() => LoggerFactory.Create(builder => { builder.AddConsole(); });

}
