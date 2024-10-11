using Bookify.Entities;

namespace Bookify.Specifications;

public class GetWishlistItemByProductIdSpecification : BaseSpecification<WishlistItem>
{
	public GetWishlistItemByProductIdSpecification(int productId) : base(wlItem => wlItem.BookId == productId)
	{
		AddIncludes(wlItem => wlItem.Book);
		AddIncludes(wlItem => wlItem.Wishlist);
	}
}
