using Lab.Technical.Exercise.Domain.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Technical.Exercise.Infrastructure.EntityConfigurations
{
    public class LabelEntityTypeConfiguration : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd().IsRequired();
        }
    }
}