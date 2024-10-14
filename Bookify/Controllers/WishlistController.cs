using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
[Authorize]
public class WishlistController(
    IWishlistService wishlistService,
    ILogger<WishlistController> logger) : Controller
{
    private readonly IWishlistService _wishlistService = wishlistService;
    private readonly ILogger<WishlistController> _logger = logger;

    [HttpPost]
    public async Task<IActionResult> AddProductToWishlist(int productId)
    {
        var idAddedOrRemoved = await _wishlistService.AddProductToWishlistOrRemoveItAsync(productId);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Index()
    {
        var userWishlist = await _wishlistService.GetUserWishlistAsync();

        if (userWishlist.IsSuccess)
            return View(userWishlist.Value);

        return View("EmptyWishlist");
    }
}
