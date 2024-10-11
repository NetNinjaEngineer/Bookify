using Bookify.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Data.Config;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
	public void Configure(EntityTypeBuilder<Review> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id).ValueGeneratedOnAdd();

		builder.Property(x => x.ReviewerName)
			.HasMaxLength(50);

		builder.HasOne(x => x.Book)
			.WithMany(x => x.Reviews)
			.OnDelete(DeleteBehavior.SetNull)
			.HasForeignKey(x => x.BookId)
			.IsRequired(false);

		builder.ToTable("Reviews");
	}
}
