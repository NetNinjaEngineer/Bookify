using Bookify.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Data.Config;

public class BookTagConfiguration : IEntityTypeConfiguration<BookTag>
{
	public void Configure(EntityTypeBuilder<BookTag> builder)
	{
		builder.HasKey(x => new { x.TagId, x.BookId });

		builder.ToTable("BookTags");
	}
}
