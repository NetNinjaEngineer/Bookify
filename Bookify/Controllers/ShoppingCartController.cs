using AspNetCoreHero.ToastNotification.Abstractions;
using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
	[Authorize]
	public class ShoppingCartController : Controller
	{
		private readonly IShoppingCartService _shoppingCartService;
		private readonly IUserService _userService;
		private readonly ILogger<ShoppingCartController> _logger;
		private readonly IConfiguration _configuration;
		private readonly INotyfService _notyfService;

		public ShoppingCartController(
			IShoppingCartService shoppingCartService,
			IUserService userService,
			ILogger<ShoppingCartController> logger,
			IConfiguration configuration,
			INotyfService notyfService)
		{
			_shoppingCartService = shoppingCartService;
			_userService = userService;
			_logger = logger;
			_configuration = configuration;
			_notyfService = notyfService;
		}

		private Guid GetShoppingCartId()
		{
			var shoppingCartIdString = _configuration["ShoppingCartKey"];
			if (Guid.TryParse(shoppingCartIdString, out var shoppingCartId))
			{
				return shoppingCartId;
			}
			else
			{
				var newBasketId = Guid.NewGuid();
				_logger.LogWarning("Invalid ShoppingCartKey in configuration. Generated new Basket ID: {BasketId}", newBasketId);
				return newBasketId;
			}
		}

		public async Task<IActionResult> Index()
		{
			var basketId = GetShoppingCartId();
			var customerBasketResult = await _shoppingCartService.GetBasketAsync(basketId);

			if (!customerBasketResult.IsSuccess || customerBasketResult.Value == null || customerBasketResult.Value.ShoppingCartItems.Count == 0)
			{
				return View("EmptyBasket");
			}

			return View(customerBasketResult.Value);
		}

		[HttpPost("addToBasket")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddToBasket(int productId, int quantity)
		{
			var basketId = GetShoppingCartId();
			var customerEmail = _userService.UserEmail;

			var addItemResult = await _shoppingCartService.AddItemToBasketAsync(basketId, customerEmail, productId, quantity);

			if (addItemResult.IsSuccess)
			{
				_notyfService.Success("Item added to the basket successfully.");
			}
			else
			{
				_notyfService.Error(addItemResult.Error ?? "Failed to add item to the basket.");
				_logger.LogError("AddToBasket failed: {Error}", addItemResult.Error);
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpPost("removeItem")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RemoveItem(Guid itemId)
		{
			var basketId = GetShoppingCartId();

			var removeItemResult = await _shoppingCartService.RemoveItemFromBasketAsync(basketId, itemId);

			if (removeItemResult.IsSuccess)
			{
				_notyfService.Success("Item removed from the basket successfully.");
			}
			else
			{
				_notyfService.Error(removeItemResult.Error ?? "Failed to remove item from the basket.");
				_logger.LogError("RemoveItem failed: {Error}", removeItemResult.Error);
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpPost("updateQuantity")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateQuantity(Guid itemId, int quantity)
		{
			var basketId = GetShoppingCartId();

			var updateQuantityResult = await _shoppingCartService.UpdateItemQuantityInBasketAsync(basketId, itemId, quantity);

			if (updateQuantityResult.IsSuccess)
			{
				_notyfService.Success("Item quantity updated successfully.");
			}
			else
			{
				_notyfService.Error(updateQuantityResult.Error ?? "Failed to update item quantity.");
				_logger.LogError("UpdateQuantity failed: {Error}", updateQuantityResult.Error);
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpPost("clearBasket")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ClearBasket()
		{
			var basketId = GetShoppingCartId();

			var clearBasketResult = await _shoppingCartService.DeleteBasketAsync(basketId);

			if (clearBasketResult.IsSuccess)
			{
				_notyfService.Success("Basket cleared successfully.");
			}
			else
			{
				_notyfService.Error(clearBasketResult.Error ?? "Failed to clear the basket.");
				_logger.LogError("ClearBasket failed: {Error}", clearBasketResult.Error);
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
