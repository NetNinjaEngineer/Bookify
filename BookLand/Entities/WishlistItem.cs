namespace Bookify.Entities;

public class WishlistItem : BaseEntity
{
	public DateTimeOffset DateAdded { get; set; }

	public int BookId { get; set; }

	public Book Book { get; set; } = null!;

	public int WishlistId { get; set; }

	public Wishlist Wishlist { get; set; } = null!;
}
