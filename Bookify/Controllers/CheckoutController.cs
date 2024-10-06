using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
public class CheckoutController : Controller
{
    private readonly IOrderService _orderService;

    public CheckoutController(IOrderService orderService)
    {
        _orderService = orderService;
    }


}
