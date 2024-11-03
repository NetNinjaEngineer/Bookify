using AutoMapper;
using Bookify.Abstractions;
using Bookify.Entities;
using Bookify.Models;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.ViewModels;
using StackExchange.Redis;
using System.Text.Json;

namespace Bookify.Services
{
	public class ShoppingCartService : IShoppingCartService
	{
		private readonly IDatabase _database;
		private readonly IGenericRepository<Book> _bookRepository;
		private readonly IMapper _mapper;
		private const string CartKeyPrefix = "cart:";

		public ShoppingCartService(
			IConnectionMultiplexer connection,
			IGenericRepository<Book> bookRepository,
			IMapper mapper)
		{
			_database = connection.GetDatabase();
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		private string GetCartKey(Guid basketId) => $"{CartKeyPrefix}{basketId}";

		public async Task<Result<ShoppingCart>> AddItemToBasketAsync(Guid basketId, string customerEmail, int productId, int quantity)
		{
			if (quantity < 1)
				return Result<ShoppingCart>.Fail("Quantity must be at least 1.");

			var book = await _bookRepository.GetByIdAsync(productId);
			if (book == null)
				return Result<ShoppingCart>.Fail("Book not found.");

			if (book.StockQuantity < quantity)
				return Result<ShoppingCart>.Fail("Insufficient stock for the book.");

			var customerShoppingCart = (await GetBasketAsync(basketId)).Value
				?? new ShoppingCart
				{
					BasketId = basketId,
					CustomerEmail = customerEmail,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now,
					ShoppingCartItems = new List<ShoppingCartItem>()
				};

			var existingItem = customerShoppingCart?.ShoppingCartItems
				.FirstOrDefault(scItem => scItem.ProductId == productId);

			if (existingItem != null)
			{
				existingItem.Quantity += quantity;
			}
			else
			{
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

				customerShoppingCart?.ShoppingCartItems.Add(shoppingCartItem);
			}

			var updateResult = await UpdateBasketAsync(customerShoppingCart);
			if (updateResult == null)
				return Result<ShoppingCart>.Fail("Failed to update the shopping cart.");

			return Result<ShoppingCart>.Ok(updateResult.Value);
		}

		public async Task<Result<bool>> DeleteBasketAsync(Guid basketId)
		{
			var deleted = await _database.KeyDeleteAsync(GetCartKey(basketId));
			if (!deleted)
				return Result<bool>.Fail("Failed to delete the shopping cart.");

			return Result<bool>.Ok(true);
		}

		public async Task<Result<ShoppingCart>> GetBasketAsync(Guid basketId)
		{
			var basket = await _database.StringGetAsync(GetCartKey(basketId));
			if (basket.IsNullOrEmpty)
				return Result<ShoppingCart>.Fail("Shopping cart not found.");

			try
			{
				var shoppingCart = JsonSerializer.Deserialize<ShoppingCart>(basket);
				if (shoppingCart == null)
					return Result<ShoppingCart>.Fail("Failed to deserialize the shopping cart.");

				return Result<ShoppingCart>.Ok(shoppingCart);
			}
			catch (JsonException)
			{
				return Result<ShoppingCart>.Fail("Invalid shopping cart data.");
			}
		}

		public async Task<Result<int>> GetItemsCountInBasketAsync(Guid basketId)
		{
			var basketResult = await GetBasketAsync(basketId);
			if (!basketResult.IsSuccess)
				return Result<int>.Fail(basketResult.Error ?? "Failed to retrieve the shopping cart.");

			var count = basketResult.Value?.ShoppingCartItems.Count ?? 0;
			return Result<int>.Ok(count);
		}

		public async Task<Result<ShoppingCart>> RemoveItemFromBasketAsync(Guid basketId, Guid itemId)
		{
			var basketResult = await GetBasketAsync(basketId);
			if (!basketResult.IsSuccess)
				return Result<ShoppingCart>.Fail(basketResult.Error ?? "Shopping cart not found.");

			var customerShoppingCart = basketResult.Value!;
			var existedItem = customerShoppingCart.ShoppingCartItems
				.FirstOrDefault(scItem => scItem.Id == itemId);

			if (existedItem == null)
				return Result<ShoppingCart>.Fail($"Item with ID {itemId} not found in the shopping cart.");

			customerShoppingCart.ShoppingCartItems.Remove(existedItem);

			var updateResult = await UpdateBasketAsync(customerShoppingCart);
			if (updateResult == null)
				return Result<ShoppingCart>.Fail("Failed to update the shopping cart after removing the item.");

			return Result<ShoppingCart>.Ok(updateResult.Value);
		}

		public async Task<Result<ShoppingCart>> UpdateBasketAsync(ShoppingCart basket)
		{
			var jsonShoppingCart = JsonSerializer.Serialize(basket);
			var setResult = await _database.StringSetAsync(GetCartKey(basket.BasketId), jsonShoppingCart);
			if (!setResult)
				return Result<ShoppingCart>.Fail("Failed to update the shopping cart in the database.");

			return await GetBasketAsync(basket.BasketId);
		}

		public async Task<Result<ShoppingCart>> UpdateItemQuantityInBasketAsync(Guid basketId, Guid itemId, int quantity)
		{
			if (quantity < 1)
				return Result<ShoppingCart>.Fail("Quantity must be at least 1.");

			var basketResult = await GetBasketAsync(basketId);
			if (!basketResult.IsSuccess)
				return Result<ShoppingCart>.Fail(basketResult.Error ?? "Shopping cart not found.");

			var shoppingCart = basketResult.Value!;
			var existedBasketItem = shoppingCart.ShoppingCartItems
				.FirstOrDefault(x => x.Id == itemId);

			if (existedBasketItem == null)
				return Result<ShoppingCart>.Fail($"Item with ID {itemId} not found in the shopping cart.");

			var book = await _bookRepository.GetByIdAsync(existedBasketItem.ProductId);
			if (book == null)
				return Result<ShoppingCart>.Fail("Book not found.");

			if (book.StockQuantity < quantity)
				return Result<ShoppingCart>.Fail("Insufficient stock for the book.");

			existedBasketItem.Quantity = quantity;

			var updateResult = await UpdateBasketAsync(shoppingCart);
			if (updateResult == null)
				return Result<ShoppingCart>.Fail("Failed to update the shopping cart after updating the item quantity.");

			return Result<ShoppingCart>.Ok(updateResult.Value);
		}
	}
}
