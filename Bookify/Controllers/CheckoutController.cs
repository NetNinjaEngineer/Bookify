using Bookify.Abstractions;
using Bookify.Entities.OrderAggregate;
using Bookify.Helpers.PaymentModels;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Text.Json;

namespace Bookify.Controllers;

[Authorize]
[Route("checkout")]
public class CheckoutController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IUserService _userService;
    private readonly string _customerEmail;
    private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepository;
    private readonly IConfiguration _configuration;
    private readonly ILogger<CheckoutController> _logger;
    private readonly IHttpClientFactory _clientFactory;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IGenericRepository<Order> _orderRepository;

    public CheckoutController(
        IOrderService orderService,
        IUserService userService,
        IGenericRepository<DeliveryMethod> deliveryMethodRepository,
        IConfiguration configuration,
        ILogger<CheckoutController> logger,
        IHttpClientFactory clientFactory,
        IShoppingCartService shoppingCartService,
        IGenericRepository<Order> orderRepository)
    {
        _orderService = orderService;
        _userService = userService;
        _customerEmail = _userService.UserEmail;
        _deliveryMethodRepository = deliveryMethodRepository;
        _configuration = configuration;
        _logger = logger;
        _clientFactory = clientFactory;
        _shoppingCartService = shoppingCartService;
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Checkout(int orderId)
    {
        var customerOrder = await _orderService.GetUserOrderAsync(_customerEmail, orderId);
        ViewBag.CustomerOrderId = customerOrder!.Id;
        return View(customerOrder);
    }

    [HttpPost("create-checkout-session")]
    public async Task<IActionResult> CreateCheckoutSession([FromQuery] int orderId)
    {
        try
        {
            var customerOrder = await _orderService.GetUserOrderAsync(_customerEmail, orderId);

            if (customerOrder is null)
                return BadRequest($"No Order found for customer {_customerEmail}");

            var domain = _configuration["BaseUrl"];

            var lineItems = customerOrder.OrderItems
                .Select(item => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.ProductItemOrdered.ProductName,
                            Images = [item.ProductItemOrdered.PictureUrl!]
                        },
                        UnitAmount = (long)(item.UnitPrice * 100),
                    },
                    Quantity = item.Quantity
                }).ToList();

            // Add delivery method as a line item

            var selectedUserDeliveryMethod = await _deliveryMethodRepository.GetByIdAsync(customerOrder.DeliveryMethodId);

            if (selectedUserDeliveryMethod is null)
                return BadRequest("Invalid Delivery Method Selected !!!");

            lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = selectedUserDeliveryMethod.Title,
                        Description = "Delivery charges",
                    },
                    UnitAmount = (long)(selectedUserDeliveryMethod.Cost * 100),
                },
                Quantity = 1
            });

            var shopCart = await _shoppingCartService.GetBasketAsync(Guid.Parse(_configuration["shoppingCartKey"]!));

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = ["card"],
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = $"{domain}/checkout/success?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{domain}/Checkout/Cancel",
                Metadata = new Dictionary<string, string>
                {
                    { "OrderId", customerOrder.Id.ToString() },
                    { "shoppingCartId", shopCart.Value.BasketId.ToString() }
                }
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            return Ok(new { orderId = customerOrder.Id, sessionId = session.Id });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("success")]
    public async Task<IActionResult> Success([FromQuery] string session_id)
    {
        var service = new SessionService();
        var checkoutSession = await service.GetAsync(session_id);

        var paymentStatus = checkoutSession.PaymentStatus;

        _logger.LogInformation($"Session Customer ID: {checkoutSession.CustomerId}");
        _logger.LogInformation($"Checkout Session: {JsonSerializer.Serialize(checkoutSession)}");

        if (paymentStatus == "paid")
        {
            var lineItemsResult = await RetrieveCheckoutLineItemsAsync(checkoutSession.Id);

            if (lineItemsResult.IsSuccess)
            {
                // Create the invoice with line items
            }


            var order = await _orderService.GetUserOrderAsync(_userService.UserEmail, Convert.ToInt32(checkoutSession.Metadata["OrderId"]));

            if (order is not null)
            {
                // change order status to paid
                order.OrderStatus = OrderStatus.Paid;
                _orderRepository.Update(order);
            }

            var basketId = Guid.Parse(checkoutSession.Metadata["shoppingCartId"]);

            await _shoppingCartService.DeleteBasketAsync(basketId);
        }

        return View();
    }

    private async Task<Result<CheckoutLineItemResponse>> RetrieveCheckoutLineItemsAsync(string id)
    {
        var client = _clientFactory.CreateClient("StripeClient");
        var response = await client.GetAsync($"/v1/checkout/sessions/{id}/line_items");

        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<CheckoutLineItemResponse>(responseData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            _logger.LogInformation("Successfully retrieved line items: {Response}", responseData);
            return Result<CheckoutLineItemResponse>.Ok(jsonResponse);
        }

        var errorContent = await response.Content.ReadAsStringAsync();
        _logger.LogError("Error retrieving line items: {StatusCode} - {ErrorContent}", response.StatusCode, errorContent);

        return Result<CheckoutLineItemResponse>.Fail($"Error retrieving line items: {response.StatusCode} - {errorContent}");
    }


}
