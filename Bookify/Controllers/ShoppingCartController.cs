using Bookify.Exceptions;
using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;

[Authorize]
public class ShoppingCartController : Controller
{
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IUserService _userService;
    private readonly ILogger<ShoppingCartController> _logger;
    private readonly string _customerEmail;
    private readonly IConfiguration _configuration;

    public ShoppingCartController(
        IShoppingCartService shoppingCartService,
        ILogger<ShoppingCartController> logger,
        IUserService userService,
        IConfiguration configuration)
    {
        _shoppingCartService = shoppingCartService;
        _logger = logger;
        _userService = userService;
        _customerEmail = _userService.UserEmail;
        _configuration = configuration;
    }

    private string GetShoppingCartId() => _configuration["shoppingCartKey"]!;

    public async Task<IActionResult> Index()
    {
        var customerBasket = await _shoppingCartService.GetBasketAsync(Guid.Parse(GetShoppingCartId()));
        if (customerBasket == null)
            return View("EmptyBasket");

        return View(customerBasket);
    }


    // solve problems with this method
    [HttpPost("addToBasket")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToBasket(int productId, int quantity)
    {
        var updatedCustomerBasket = await _shoppingCartService.AddItemToBasketAsync(Guid.Parse(GetShoppingCartId()), _customerEmail, productId, quantity);

        if (updatedCustomerBasket.IsSuccess)
            return RedirectToAction(nameof(Index));

        _logger.LogError(updatedCustomerBasket.Error);

        return View(); // throws error should be handled again
    }

    [HttpPost("removeItem")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveItem(Guid itemId)
    {
        try
        {
            var updatedCustomerBasket = await _shoppingCartService.RemoveItemFromBasketAsync(Guid.Parse(GetShoppingCartId()), itemId);
            if (updatedCustomerBasket == null)
            {
                TempData["Error"] = "No available basket.";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        catch (BasketItemNotFoundException ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    [HttpPost("updateQuantity")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateQuantity(Guid itemId, int quantity)
    {
        try
        {
            var updatedCustomerBasket = await _shoppingCartService.UpdateItemQuantityInBasketAsync(Guid.Parse(GetShoppingCartId()), itemId, quantity);
            if (updatedCustomerBasket == null)
            {
                TempData["Error"] = "No basket available.";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        catch (BasketItemNotFoundException ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    [HttpPost("clearBasket")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ClearBasket()
    {
        await _shoppingCartService.DeleteBasketAsync(Guid.Parse(GetShoppingCartId()));
        return RedirectToAction("Index");
    }
}
