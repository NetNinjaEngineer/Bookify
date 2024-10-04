using Bookify.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Data.Config;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.FirstName)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

    }
}
