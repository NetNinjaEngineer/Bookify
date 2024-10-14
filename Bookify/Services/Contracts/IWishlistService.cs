using Bookify.Abstractions;
using Bookify.ViewModels;

namespace Bookify.Services.Contracts;

public interface IWishlistService
{
	Task<(Result<int>, bool)> AddProductToWishlistOrRemoveItAsync(int productId);
	Task<Result<int>> CreateUserWishlistAsync(string customerEmail);
	Task<Result> RemoveProductFromWishlist(int productId);
	Task<Result<WishlistForListVM>> GetUserWishlistAsync();
	Task<Result<int>> GetUserWishlistItemsCountAsync();
}