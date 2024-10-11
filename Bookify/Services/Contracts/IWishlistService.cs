using Bookify.Abstractions;

namespace Bookify.Services.Contracts;

public interface IWishlistService
{
	Task<Result<int>> AddProductToWishlistOrRemoveItAsync(int productId);
	Task<Result<int>> CreateUserWishlistAsync(string customerEmail);
	Task<Result> RemoveProductFromWishlist(int productId);
}