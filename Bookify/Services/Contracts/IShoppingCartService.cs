using Bookify.Abstractions;
using Bookify.Models;

namespace Bookify.Services.Contracts;

public interface IShoppingCartService
{
	Task<Result<ShoppingCart>> GetBasketAsync(Guid basketId);
	Task<Result<ShoppingCart>> UpdateBasketAsync(ShoppingCart basket);
	Task<Result<bool>> DeleteBasketAsync(Guid basketId);
	Task<Result<ShoppingCart>> AddItemToBasketAsync(Guid basketId, string customerEmail, int productId, int quantity);
	Task<Result<ShoppingCart>> RemoveItemFromBasketAsync(Guid basketId, Guid itemId);
	Task<Result<ShoppingCart>> UpdateItemQuantityInBasketAsync(Guid basketId, Guid itemId, int quantity);
	Task<Result<int>> GetItemsCountInBasketAsync(Guid basketId);
}
