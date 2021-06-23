using Lab.Technical.Exercise.Domain.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Technical.Exercise.Infrastructure.EntityConfigurations
{
    class StockEntityTypeConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.AlbumId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd().IsRequired();
        }

    }
}
