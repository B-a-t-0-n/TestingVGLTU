using Microsoft.EntityFrameworkCore;

namespace TestingVGLTU.Data
{
    public class DataContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }
}
