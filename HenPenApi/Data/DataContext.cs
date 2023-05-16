using HenPenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HenPenApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Hen> Hens => Set<Hen>();
        public DbSet<Breed> Breeds => Set<Breed>();
        public DbSet<Feed> Feeds => Set<Feed>();
        public DbSet<Consumption> Consumptions => Set<Consumption>();
        public DbSet<EggProduction> Eggs => Set<EggProduction>();
        public DbSet<HealthIssue> HealthIssues => Set<HealthIssue>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feed>()
                .Property(f => f.UnitPrice)
                .HasColumnType("decimal(18,2)"); // Adjusting the precision and scale

            modelBuilder.Entity<Hen>()
                .Property(h => h.Breed)
                .IsRequired();

            var breedConverter = new BreedConverter();
            modelBuilder.Entity<Hen>()
                .Property(h => h.Breed)
                .HasConversion(breedConverter);

            base.OnModelCreating(modelBuilder);
        }
    }
}
