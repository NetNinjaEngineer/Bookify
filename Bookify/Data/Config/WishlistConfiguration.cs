using Bookify.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Data.Config;

public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
{
	public void Configure(EntityTypeBuilder<Wishlist> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();

		builder.HasOne(x => x.User).WithOne().IsRequired();

		builder.HasMany(x => x.WishlistItems)
			.WithOne(x => x.Wishlist)
			.HasForeignKey(x => x.WishlistId)
			.IsRequired();

		builder.ToTable("Wishlist");
	}
}