﻿using Bookify.Models;

namespace Bookify.Repository.Contracts;

public interface IBasketRepository
{
    Task<CustomerBasket?> GetBasketAsync(string basketId);
    Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBaskeyAsync(string basketId);
    Task<CustomerBasket?> AddItemToBasketAsync(string basketId, BasketItem basketItem);
    Task<CustomerBasket?> RemoveItemFromBasketAsync(string basketId, int itemId);
    Task<CustomerBasket?> UpdateItemQuantityInBasketAsync(string basketId, int itemId, int quantity);
}
