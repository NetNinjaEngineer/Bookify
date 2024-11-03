using AspNetCoreHero.ToastNotification.Abstractions;
using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
[Authorize]
public class WishlistController(
	IWishlistService wishlistService,
	ILogger<WishlistController> logger,
	INotyfService notyfService) : Controller
{
	private readonly IWishlistService _wishlistService = wishlistService;
	private readonly ILogger<WishlistController> _logger = logger;
	private readonly INotyfService _notyfService = notyfService;

	[HttpPost]
	public async Task<IActionResult> AddProductToWishlist(int productId)
	{
		var (idAddedOrRemovedResult, added) = await _wishlistService.AddProductToWishlistOrRemoveItAsync(productId);

		if (idAddedOrRemovedResult.IsSuccess)
		{
			if (added)
			{
				_notyfService.Success("Successfully added to your wishlist.");
				return RedirectToAction("Index");
			}

			_notyfService.Success("Removed from your wishlist.");

			return RedirectToAction("Details", "Books", new { id = productId });

		}

		_notyfService.Error(idAddedOrRemovedResult.Error);

		return RedirectToAction("Details", "Books", new { id = productId });
	}

	public async Task<IActionResult> Index()
	{
		var userWishlist = await _wishlistService.GetUserWishlistAsync();

		if (userWishlist.IsSuccess)
			return View(userWishlist.Value);

		return View("EmptyWishlist");
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> RemoveProductFromWishlist(int productId)
	{
		var removedResult = await _wishlistService.RemoveProductFromWishlist(productId);
		if (removedResult.IsSuccess)
		{
			_notyfService.Success("Removed Successfully from your wishlist.");
			return RedirectToAction("Index");
		}

		_notyfService.Error(removedResult.Error);
		return RedirectToAction(nameof(Index));
	}
}
