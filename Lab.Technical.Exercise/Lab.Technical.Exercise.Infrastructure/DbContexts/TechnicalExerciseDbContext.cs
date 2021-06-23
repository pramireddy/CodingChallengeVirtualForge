using Lab.Technical.Exercise.Domain.EntityModels;
using Lab.Technical.Exercise.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Lab.Technical.Exercise.Infrastructure.DbContexts
{
    public class TechnicalExerciseDbContext : DbContext
    {
        public TechnicalExerciseDbContext(DbContextOptions<TechnicalExerciseDbContext> options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<Label>().ToTable("Label");
            modelBuilder.Entity<Stock>().ToTable("Stock");

            modelBuilder.ApplyConfiguration(new AlbumEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LabelEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StockEntityTypeConfiguration());
        }
    }
}