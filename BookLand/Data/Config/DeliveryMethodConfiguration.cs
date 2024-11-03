using Bookify.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Data.Config;

public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
{
    public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .HasColumnType("varchar").HasMaxLength(128)
            .IsRequired();

        builder.Property(x => x.Cost)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder.ToTable("DeliveryMethods");
    }
}
