using Bookify.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Data.Config;

public class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItem>
{
	public void Configure(EntityTypeBuilder<WishlistItem> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();

		builder.HasOne(x => x.Book).WithOne().IsRequired();

		builder.ToTable("WishlistItems");
	}
}
