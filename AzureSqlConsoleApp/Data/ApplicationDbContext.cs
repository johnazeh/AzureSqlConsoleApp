using Microsoft.EntityFrameworkCore;
using AzureSqlConsoleApp.Models;

namespace AzureSqlConsoleApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyDataModel> MyData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyDataModel>()
                .ToTable("Customerdemo", "dbo")
                .HasKey(m => m.CustomerId); // Configure primary key
        }
    }
}