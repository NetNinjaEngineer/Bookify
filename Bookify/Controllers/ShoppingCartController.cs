using Bookify.Exceptions;
using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;

[Authorize]
public class ShoppingCartController : Controller
{
    private readonly Guid _basketId = Guid.Parse("BD59E9A8-7B75-419B-ACCD-E68DC42DFB57");
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IUserService _userService;
    private readonly ILogger<ShoppingCartController> _logger;
    private readonly string _customerEmail;

    public ShoppingCartController(
        IShoppingCartService shoppingCartService,
        ILogger<ShoppingCartController> logger,
        IUserService userService)
    {
        _shoppingCartService = shoppingCartService;
        _logger = logger;
        _userService = userService;
        _customerEmail = _userService.UserEmail;
    }

    public async Task<IActionResult> Index()
    {
        var customerBasket = await _shoppingCartService.GetBasketAsync(_basketId);
        if (customerBasket == null)
            return View("EmptyBasket");

        return View(customerBasket);
    }

    [HttpPost("addToBasket")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToBasket(int productId, int quantity)
    {
        try
        {
            var updatedCustomerBasket = await _shoppingCartService.AddItemToBasketAsync(_basketId, _customerEmail, productId, quantity);
            if (updatedCustomerBasket == null)
            {
                TempData["Error"] = "Failed to add item to the basket.";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return View("Error");
        }
    }

    [HttpPost("removeItem")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveItem(Guid itemId)
    {
        try
        {
            var updatedCustomerBasket = await _shoppingCartService.RemoveItemFromBasketAsync(_basketId, itemId);
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
            var updatedCustomerBasket = await _shoppingCartService.UpdateItemQuantityInBasketAsync(_basketId, itemId, quantity);
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
        await _shoppingCartService.DeleteBasketAsync(_basketId);
        return RedirectToAction("Index");
    }
}
