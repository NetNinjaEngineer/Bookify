using Bookify.Exceptions;
using Bookify.Models;
using Bookify.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;

public class BasketController : Controller
{
    private readonly string _basketId = "CUS_BA0111";
    private readonly IBasketRepository _basketRepository;

    public BasketController(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<IActionResult> Index()
    {
        var customerBasket = await _basketRepository.GetBasketAsync(_basketId);
        if (customerBasket == null)
            return View("EmptyBasket");

        return View(customerBasket);
    }

    [HttpPost("addToBasket")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToBasket([FromForm] BasketItem basketItem)
    {
        var updatedCustomerBasket = await _basketRepository.AddItemToBasketAsync(_basketId, basketItem);
        if (updatedCustomerBasket == null)
        {
            TempData["Error"] = "Failed to add item to the basket.";
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    [HttpPost("removeItem")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveItem(int itemId)
    {
        try
        {
            var updatedCustomerBasket = await _basketRepository.RemoveItemFromBasketAsync(_basketId, itemId);
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
    public async Task<IActionResult> UpdateQuantity(int itemId, int quantity)
    {
        try
        {
            var updatedCustomerBasket = await _basketRepository.UpdateItemQuantityInBasketAsync(_basketId, itemId, quantity);
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
        await _basketRepository.DeleteBaskeyAsync(_basketId);
        return RedirectToAction("Index");
    }
}
