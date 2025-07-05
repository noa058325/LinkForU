using Microsoft.EntityFrameworkCore;
using links.Entities;
using Microsoft.Extensions.Configuration;

namespace links.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Web> Web { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Recommend> Recommend { get; set; }
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Web>().ToTable("Webs");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Recommend>().ToTable("Recommends");
        }
    }
}
