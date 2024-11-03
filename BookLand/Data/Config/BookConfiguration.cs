using Bookify.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Data.Config;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
	public void Configure(EntityTypeBuilder<Book> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();

		builder.Property(x => x.Title)
			.HasColumnType("varchar").HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.Description)
			.HasColumnType("varchar").HasMaxLength(255)
			.IsRequired();

		builder.Property(x => x.Price)
			.HasPrecision(18, 2)
			.IsRequired();

		builder.HasOne(x => x.Genre)
			.WithMany(x => x.Books)
			.HasForeignKey(x => x.GenreId)
			.OnDelete(DeleteBehavior.SetNull)
			.IsRequired(false);

		builder.HasOne(x => x.Author)
			.WithMany(x => x.Books)
			.HasForeignKey(x => x.AuthorId)
			.OnDelete(DeleteBehavior.SetNull)
			.IsRequired(false);

		builder.Property(b => b.EditionLanguage)
			.HasConversion(
				editionLang => editionLang.ToString(),
				editionLang => (EditionLanguage)Enum.Parse(typeof(EditionLanguage), editionLang)
			);

		builder.HasMany(x => x.Tags)
			.WithMany(x => x.Books)
			.UsingEntity<BookTag>();

		builder.HasOne(x => x.Publisher)
			.WithMany(x => x.Books)
			.HasForeignKey(x => x.PublisherId)
			.OnDelete(DeleteBehavior.SetNull)
			.IsRequired(false);

		builder.HasQueryFilter(x => x.StockQuantity > 0);

		builder.ToTable("Books");
	}
}
