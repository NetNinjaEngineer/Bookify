namespace Bookify.ViewModels;

public class WishlistItemVM
{
	public int ProductId { get; set; }
	public string ProductName { get; set; } = string.Empty;
	public string ProductImageUrl { get; set; } = string.Empty;
	public decimal Price { get; set; }
}