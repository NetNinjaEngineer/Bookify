using AutoMapper;
using Bookify.Entities.OrderAggregate;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookify.Controllers;

[Authorize]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepository;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public OrdersController(
        IOrderService orderService,
        IGenericRepository<DeliveryMethod> deliveryMethodRepository,
        IShoppingCartService shoppingCartService,
        IUserService userService,
        IMapper mapper)
    {
        _orderService = orderService;
        _deliveryMethodRepository = deliveryMethodRepository;
        _shoppingCartService = shoppingCartService;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<IActionResult> GetAllUserOrders()
    {
        var userOrders = await _orderService.GetUserOrdersAsync(_userService.UserEmail);
        var mappedOrders = _mapper.Map<IEnumerable<OrderForListVM>>(userOrders);
        return View(mappedOrders);
    }


    [HttpGet]
    public async Task<IActionResult> PlaceOrder(Guid shoppingCartId)
    {
        // send shoppingCartId to PlaceOrder View

        ViewBag.ShoppingCartId = shoppingCartId;

        // load all delivery methods to PlaceOrder View

        var deliveryMethods = new SelectList(
            items: await _deliveryMethodRepository.GetAllAsync(),
            dataValueField: "Id",
            dataTextField: "Title"
        );

        var shoppingCart = (await _shoppingCartService.GetBasketAsync(shoppingCartId)).Value;

        ViewBag.ShoppingCart = shoppingCart;

        ViewBag.DeliveryMethods = deliveryMethods;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PlaceOrder(CreateOrderRequestVM createOrderRequestVM)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdOrder = await _orderService.CreateOrderAsync(createOrderRequestVM);

        if (createdOrder == null)
            return BadRequest("Unable to Create Order.");

        // order is created

        return RedirectToAction("Checkout", "Checkout", new { orderId = createdOrder.Id });
    }
}