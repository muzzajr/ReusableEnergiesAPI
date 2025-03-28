using Microsoft.EntityFrameworkCore;
using RenewableEnergiesApi.Models;

namespace RenewableEnergiesApi.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<RenewableEnergiesData> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RenewableEnergies.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RenewableEnergiesData>().HasKey(r => r.Id); // Configure the primary key
        }
    }

    
}


