using Bookify.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Data.Config;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.OrderStatus)
            .HasConversion(
                x => x.ToString(),
                x => (OrderStatus)Enum.Parse(typeof(OrderStatus), x.ToString())
            );

        builder.OwnsOne(x => x.ShippingAddress, options =>
        {
            options.Property(x => x.ShippingAddressLine1)
                .HasColumnName("ShippingAddressLine1")
                .HasMaxLength(100)
                .IsRequired();

            options.Property(x => x.ShippingAddressLine2)
               .HasColumnName("ShippingAddressLine2")
               .HasMaxLength(100)
               .IsRequired();

            options.Property(x => x.FirstName)
               .HasColumnName("FirstName")
               .HasMaxLength(50)
               .IsRequired();


            options.Property(x => x.LastName)
               .HasColumnName("LastName")
               .HasMaxLength(50)
               .IsRequired();


            options.Property(x => x.ShippingCity)
               .HasColumnName("ShippingCity")
               .HasMaxLength(50)
               .IsRequired();

            options.Property(x => x.ShippingCountry)
                .HasColumnName("ShippingCountry")
                .HasMaxLength(50)
                .IsRequired();


            options.Property(x => x.ShippingPostalCode)
                .HasColumnName("ShippingPostalCode")
                .HasMaxLength(50)
                .IsRequired();


            options.Property(x => x.ShippingState)
                .HasColumnName("ShippingState")
                .HasMaxLength(50)
                .IsRequired();

        });

        builder.Property(x => x.CustomerEmail)
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.HasOne(x => x.DeliveryMethod)
            .WithMany()
            .HasForeignKey(x => x.DeliveryMethodId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();


        builder.HasMany(x => x.OrderItems)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(x => x.TotalAmount)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();


        builder.ToTable("Orders");
    }
}
