using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
[Authorize]
public class WishlistController : Controller
{
	private readonly IWishlistService _wishlistService;
	private readonly IUserService _userService;

	public WishlistController(IWishlistService wishlistService, IUserService userService)
	{
		_wishlistService = wishlistService;
		_userService = userService;
	}

	[HttpPost]
	public async Task<IActionResult> AddProductToWishlist(int productId)
	{
		var productIdCreated = await _wishlistService.AddProductToWishlistOrRemoveItAsync(productId, _userService.UserEmail);
		return RedirectToAction(nameof(Index));
	}

	public IActionResult Index()
	{
		return View();
	}
}
