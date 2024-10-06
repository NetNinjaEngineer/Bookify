﻿using Bookify.Entities.OrderAggregate;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookify.Controllers;
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepository;

    public OrdersController(
        IOrderService orderService,
        IGenericRepository<DeliveryMethod> deliveryMethodRepository)
    {
        _orderService = orderService;
        _deliveryMethodRepository = deliveryMethodRepository;
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

        return View();
    }
}