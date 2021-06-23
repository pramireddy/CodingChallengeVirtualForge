using Lab.Technical.Exercise.Domain.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Technical.Exercise.Infrastructure.EntityConfigurations
{
    public class AlbumEntityTypeConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ArtistId).IsRequired();
            builder.Property(x => x.LabelId).IsRequired();
            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd().IsRequired();

            builder.HasOne(x => x.Artist)
                   .WithMany(a => a.Albums)
                   .HasForeignKey(x => x.ArtistId);

            builder.HasOne(x => x.Label)
                   .WithMany(a => a.Albums)
                   .HasForeignKey(x => x.LabelId);

            builder.HasOne(x => x.Stock)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}