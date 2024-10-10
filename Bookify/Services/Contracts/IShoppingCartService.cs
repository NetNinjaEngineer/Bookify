using Bookify.Models;

namespace Bookify.Services.Contracts;

public interface IShoppingCartService
{
    Task<ShoppingCart?> GetBasketAsync(Guid basketId);
    Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart basket);
    Task<bool> DeleteBasketAsync(Guid basketId);
    Task<ShoppingCart?> AddItemToBasketAsync(Guid basketId, string customerEmail, int productId, int quantity);
    Task<ShoppingCart?> RemoveItemFromBasketAsync(Guid basketId, Guid itemId);
    Task<ShoppingCart?> UpdateItemQuantityInBasketAsync(Guid basketId, Guid itemId, int quantity);
    Task<int> GetItemsCountInBasketAsync(Guid basketId);
}
