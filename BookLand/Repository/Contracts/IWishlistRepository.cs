using Bookify.Entities;

namespace Bookify.Repository.Contracts;

public interface IWishlistRepository
{
	Task<Wishlist> GetUserWishlistAsync(string userId);
}
