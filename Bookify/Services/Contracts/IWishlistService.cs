namespace Bookify.Services.Contracts;

public interface IWishlistService
{
	Task<int> AddProductToWishlistOrRemoveItAsync(int productId, string customerEmail);
	Task<int> CreateUserWishlistAsync(string customerEmail);
	Task RemoveProductFromWishlist(int productId);
}