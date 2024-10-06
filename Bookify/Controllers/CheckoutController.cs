using Bookify.Entities.OrderAggregate;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

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

    public CheckoutController(
        IOrderService orderService,
        IUserService userService,
        IGenericRepository<DeliveryMethod> deliveryMethodRepository,
        IConfiguration configuration)
    {
        _orderService = orderService;
        _userService = userService;
        _customerEmail = _userService.UserEmail;
        _deliveryMethodRepository = deliveryMethodRepository;
        _configuration = configuration;
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
                    Quantity = item.Quantity,
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
                        Description = "Delivery charges"
                    },
                    UnitAmount = (long)(selectedUserDeliveryMethod.Cost * 100),
                },
                Quantity = 1,
            });

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = ["card"],
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = $"{domain}/Checkout/Success?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{domain}/Checkout/Cancel",
                Metadata = new Dictionary<string, string>
                {
                    { "OrderId", customerOrder.Id.ToString() }
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

    public IActionResult Success(string session_id)
    {
        return View();
    }
}
