using Bookify.Data;
using Bookify.Entities;
using Bookify.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Repository;

public class WishlistRepository(ApplicationDbContext context)
	: GenericRepository<Wishlist>(context), IWishlistRepository
{
	public async Task<Wishlist> GetUserWishlistAsync(string userId)
	{
		var userWishlist = await context.Wishlists
			.Include(wl => wl.WishlistItems)
			.ThenInclude(wlItem => wlItem.Book)
			.Include(wl => wl.User)
			.FirstOrDefaultAsync();

		return userWishlist!;
	}
}
