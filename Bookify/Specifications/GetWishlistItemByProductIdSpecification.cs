using Bookify.Entities;

namespace Bookify.Specifications;

public class GetWishlistItemByProductIdSpecification(int productId)
	: BaseSpecification<WishlistItem>(wlItem => wlItem.BookId == productId)
{
}
