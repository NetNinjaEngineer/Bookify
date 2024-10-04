using Bookify.Exceptions;
using Bookify.Models;
using Bookify.Repository.Contracts;
using StackExchange.Redis;
using System.Text.Json;

namespace Bookify.Repository;

public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
{
    private readonly IDatabase _database = connection.GetDatabase();

    public async Task<CustomerBasket?> AddItemToBasketAsync(string basketId, BasketItem basketItem)
    {
        var customerBasket = await GetBasketAsync(basketId) ?? new CustomerBasket() { BasketId = basketId };
        // if item exists in customer basket just increase item quantity
        var existedItem = customerBasket.BasketItems.FirstOrDefault(x => x.Id == basketItem.Id);
        if (existedItem is not null)
        {
            existedItem.Quantity += basketItem.Quantity;
            return await UpdateBasketAsync(customerBasket);
        }

        customerBasket.BasketItems.Add(basketItem);
        return await UpdateBasketAsync(customerBasket);
    }

    public async Task<bool> DeleteBaskeyAsync(string basketId)
        => await _database.KeyDeleteAsync(basketId);

    public async Task<CustomerBasket?> GetBasketAsync(string basketId)
    {
        var basket = await _database.StringGetAsync(basketId);
        return basket.IsNull ? null : JsonSerializer.Deserialize<CustomerBasket>(basket!);
    }

    public async Task<CustomerBasket?> RemoveItemFromBasketAsync(string basketId, int itemId)
    {
        var customerBasket = await GetBasketAsync(basketId);
        if (customerBasket is null) return null;
        var existedBasketItem = customerBasket.BasketItems.FirstOrDefault(x => x.Id == itemId)
            ?? throw new BasketItemNotFoundException($"Item with id {itemId} not founded !!!");
        customerBasket.BasketItems.Remove(existedBasketItem);
        return await UpdateBasketAsync(customerBasket);
    }

    public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
    {
        var jsonCustomerBasket = JsonSerializer.Serialize(basket);
        var createdOrUpdatedCustomerBasket = await _database.StringSetAsync(basket.BasketId, jsonCustomerBasket);
        if (!createdOrUpdatedCustomerBasket) return null;
        return await GetBasketAsync(basket.BasketId);
    }

    public async Task<CustomerBasket?> UpdateItemQuantityInBasketAsync(string basketId, int itemId, int quantity)
    {
        var customerBasket = await GetBasketAsync(basketId);
        if (customerBasket == null) return null;
        var existedBasketItem = customerBasket.BasketItems.FirstOrDefault(x => x.Id == itemId)
            ?? throw new BasketItemNotFoundException($"Basket Item with id {itemId} not founded !!!");
        if (existedBasketItem != null)
        {
            existedBasketItem.Quantity = quantity;
            return await UpdateBasketAsync(customerBasket);
        }

        return await UpdateBasketAsync(customerBasket);

    }
}
