using Bookify.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Data.Config;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.OwnsOne(x => x.ProductItemOrdered, options =>
        {
            options.Property(x => x.PictureUrl)
                .HasColumnName("PictureUrl")
                .IsRequired();

            options.Property(x => x.ProductId)
                .HasColumnName("ProductId")
                .IsRequired();

            options.Property(x => x.ProductName)
                .HasColumnName("ProductName")
                .IsRequired();
        });

        builder.Property(x => x.UnitPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.ToTable("OrderItems");
    }
}
