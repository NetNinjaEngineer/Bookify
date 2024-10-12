using AutoMapper;
using Bookify.Abstractions;
using Bookify.Entities;
using Bookify.Exceptions;
using Bookify.Models;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.ViewModels;
using StackExchange.Redis;
using System.Text.Json;

namespace Bookify.Services;

public class ShoppingCartService(
	IConnectionMultiplexer connection,
	IGenericRepository<Book> bookRepository,
	IMapper mapper) : IShoppingCartService
{
	private readonly IDatabase _database = connection.GetDatabase();
	private readonly IGenericRepository<Book> _bookRepository = bookRepository;
	private readonly IMapper _mapper = mapper;

	public async Task<Result<ShoppingCart>> AddItemToBasketAsync(Guid basketId, string customerEmail, int productId, int quantity)
	{
		var customerShoppingCart = await GetBasketAsync(basketId)
			?? new ShoppingCart()
			{
				BasketId = basketId,
				CustomerEmail = customerEmail,
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now,
				ShoppingCartItems = []
			};

		if (quantity < 1)
			return Result<ShoppingCart>.Fail("Quantity is less than 1.");


		var book = await _bookRepository.GetByIdAsync(productId);

		if (book == null)
			return Result<ShoppingCart>.Fail("Book is found");


		if (book.StockQuantity < quantity)
			return Result<ShoppingCart>.Fail("Insufficient stock for the book.");

		// if item exists in customer basket just increase item quantity
		var existedItem = customerShoppingCart.ShoppingCartItems.FirstOrDefault(scItem => scItem.ProductId == productId);

		if (existedItem is not null)
		{
			existedItem.Quantity += quantity;

			return Result<ShoppingCart>.Ok(await UpdateBasketAsync(customerShoppingCart));
		}

		var mappedBook = _mapper.Map<BookForListVM>(book);

		var shoppingCartItem = new ShoppingCartItem
		{
			Id = Guid.NewGuid(),
			Name = book.Title,
			PictureUrl = mappedBook.PictureUrl,
			Price = mappedBook.Price,
			ProductId = mappedBook.Id,
			Quantity = quantity,
			AddedAt = DateTimeOffset.Now
		};

		customerShoppingCart.ShoppingCartItems.Add(shoppingCartItem);

		return Result<ShoppingCart>.Ok(await UpdateBasketAsync(customerShoppingCart));
	}

	public async Task<bool> DeleteBasketAsync(Guid basketId)
		=> await _database.KeyDeleteAsync(basketId.ToString());

	public async Task<ShoppingCart?> GetBasketAsync(Guid basketId)
	{
		var basket = await _database.StringGetAsync(basketId.ToString());
		return basket.IsNull ? null : JsonSerializer.Deserialize<ShoppingCart>(basket!);
	}

	public async Task<int> GetItemsCountInBasketAsync(Guid basketId)
	{
		var customerBasket = await GetBasketAsync(basketId);
		if (customerBasket?.ShoppingCartItems?.Count > 0)
			return customerBasket.ShoppingCartItems.Count;
		return 0;
	}

	public async Task<ShoppingCart?> RemoveItemFromBasketAsync(Guid basketId, Guid itemId)
	{
		var customerShoppingCart = await GetBasketAsync(basketId);

		if (customerShoppingCart is null) return null;

		var existedBasketItem = customerShoppingCart.ShoppingCartItems.FirstOrDefault(scItem => scItem.Id == itemId)
			?? throw new BasketItemNotFoundException($"Item with id {itemId} not founded !!!");

		customerShoppingCart.ShoppingCartItems.Remove(existedBasketItem);

		return await UpdateBasketAsync(customerShoppingCart);
	}

	public async Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart basket)
	{
		var jsonShoppingCart = JsonSerializer.Serialize(basket);

		var createdOrUpdatedShoppingCart = await _database.StringSetAsync(basket.BasketId.ToString(), jsonShoppingCart);

		if (!createdOrUpdatedShoppingCart) return null;

		return await GetBasketAsync(basket.BasketId);
	}

	public async Task<ShoppingCart?> UpdateItemQuantityInBasketAsync(Guid basketId, Guid itemId, int quantity)
	{
		var shoppingCart = await GetBasketAsync(basketId);

		if (shoppingCart == null) return null;

		var existedBasketItem = shoppingCart.ShoppingCartItems.FirstOrDefault(x => x.Id == itemId)
			?? throw new BasketItemNotFoundException($"Basket Item with id {itemId} not founded !!!");

		if (quantity < 1)
			throw new ArgumentException("Quantity must be at least 1.");

		var book = await _bookRepository.GetByIdAsync(existedBasketItem.ProductId)
			?? throw new ArgumentException("Book not found.");

		if (book.StockQuantity < quantity)
			throw new InvalidOperationException("Insufficient stock for the book.");

		if (existedBasketItem != null)
		{
			existedBasketItem.Quantity = quantity;
			return await UpdateBasketAsync(shoppingCart);
		}

		return await UpdateBasketAsync(shoppingCart);

	}
}
