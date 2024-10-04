using Bookify.Exceptions;
using Bookify.Models;
using Bookify.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _basketRepository;

    public BasketController(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    [HttpPost("addToBasket/{basketId}")]
    public async Task<IActionResult> AddItemToCustomerBasket(string basketId, [FromBody] BasketItem basketItem)
    {
        var updatedCustomerBasket = await _basketRepository.AddItemToBasketAsync(basketId, basketItem);
        if (updatedCustomerBasket != null)
            return Ok(updatedCustomerBasket);
        return BadRequest("Failed");
    }

    [HttpGet("{basketId}")]
    public async Task<IActionResult> GetCustomerBasket(string basketId)
    {
        var customerBasket = await _basketRepository.GetBasketAsync(basketId);
        return Ok(customerBasket);
    }

    [HttpDelete("{basketId}")]
    public async Task<IActionResult> DeleteCustomerBasket(string basketId)
    {
        await _basketRepository.DeleteBaskeyAsync(basketId);
        return NoContent();
    }

    [HttpPut("{basketId}")]
    public async Task<IActionResult> UpdateItemQuantityInBasket(string basketId, int itemId, int quantity)
    {
        try
        {
            var updatedCustomerBasket = await _basketRepository.UpdateItemQuantityInBasketAsync(basketId, itemId, quantity);
            if (updatedCustomerBasket == null)
                return BadRequest("No Basket Available");
            return Ok(updatedCustomerBasket);
        }
        catch (BasketItemNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("removeItem/{basketId}")]
    public async Task<IActionResult> RemoveItemFromBasket(string basketId, int itemId)
    {
        try
        {
            var updatedCustomerBasket = await _basketRepository.RemoveItemFromBasketAsync(basketId, itemId);
            if (updatedCustomerBasket == null)
                return BadRequest("No Available basket.");
            return Ok(updatedCustomerBasket);
        }
        catch (BasketItemNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
