namespace Bookify.Entities;

public class Wishlist : BaseEntity
{
	public string UserId { get; set; } = null!;

	public User User { get; set; } = null!;

	public ICollection<WishlistItem> WishlistItems { get; set; } = [];
}