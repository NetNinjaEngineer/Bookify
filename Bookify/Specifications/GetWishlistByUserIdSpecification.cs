using Bookify.Entities;

namespace Bookify.Specifications;

public class GetWishlistByUserIdSpecification : BaseSpecification<Wishlist>
{
	public GetWishlistByUserIdSpecification(string userId) : base(wl => wl.UserId == userId)
	{
		AddIncludes(wl => wl.User);
		AddIncludes(wl => wl.WishlistItems);
	}
}
