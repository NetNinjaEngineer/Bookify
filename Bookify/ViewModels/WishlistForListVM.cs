namespace Bookify.ViewModels;

public class WishlistForListVM
{
	public int WishlistId { get; set; }
	public List<WishlistItemVM> WishlistItemVMs { get; set; } = [];
}