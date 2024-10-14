using Bookify.Entities;
using Bookify.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Data;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Genre> Genres { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Return> Returns { get; set; }

    public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Wishlist> Wishlists { get; set; }

    public DbSet<WishlistItem> WishlistItems { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<BookTag> BookTags { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
