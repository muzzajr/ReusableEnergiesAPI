using Microsoft.EntityFrameworkCore;
using RenewableEnergiesApi.Models;

namespace RenewableEnergiesApi.DB
{
    /// <summary>
    /// Represents the database context for the Renewable Energies application.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the DbSet for accessing RenewableEnergiesData records.
        /// </summary>
        public DbSet<RenewableEnergiesData> Records { get; set; }

        /// <summary>
        /// Configures the database options for the context.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RenewableEnergies.db");
        }

        /// <summary>
        /// Configures the model for the context.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RenewableEnergiesData>().HasKey(r => r.Id);
        }
    }
}