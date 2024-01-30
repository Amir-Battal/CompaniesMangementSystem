using Microsoft.EntityFrameworkCore;

namespace APIs_Task.Models
{
    public class AppDbContext : DbContext//todo I know maybe you see this in courses but I really don't like this way putting dbContext inside the models 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Create>()
                .ToTable("creates")
                .HasKey(b => new {b.BranchId, b.ProductId});

            modelBuilder.Entity<Supply>()
                .ToTable("supplys")
                .HasKey(b => new { b.BranchId, b.ProductId });

            modelBuilder.Entity<Report>()
                .ToTable("reports")
                .HasKey(b => new {b.from, b.to});

        }

        public DbSet<Company> companies { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Create> creates { get; set; }
        public DbSet<Supply> supplys { get; set; }
        public DbSet<Report> reports { get; set; }
    }
}
