using Bookify.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Data.Config;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
	public void Configure(EntityTypeBuilder<Publisher> builder)
	{
		builder.HasKey(e => e.Id);
		builder.Property(e => e.Id).ValueGeneratedOnAdd();
	}
}
