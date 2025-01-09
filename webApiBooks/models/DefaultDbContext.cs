using Microsoft.EntityFrameworkCore;

namespace webApiBooks.models {
    public class DefaultDbContext : DbContext{
        public DefaultDbContext(DbContextOptions<DefaultDbContext>options) : base(options){
            
        }
        public DbSet<Authors> Authors{ get; set; }
        public DbSet<Books> Books{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Authors>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Books>().HasIndex(c => c.Id).IsUnique();
        }
    }
}
