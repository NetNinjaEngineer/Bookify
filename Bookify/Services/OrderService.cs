using AutoMapper;
using Bookify.Entities;
using Bookify.Entities.OrderAggregate;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.Specifications;
using Bookify.ViewModels;

namespace Bookify.Services;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepository;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IGenericRepository<Book> _bookRepository;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IUserService _userService;

    public OrderService(
        IGenericRepository<DeliveryMethod> deliveryMethodRepository,
        IShoppingCartService shoppingCartService,
        IGenericRepository<Book> bookRepository,
        IMapper mapper,
        IGenericRepository<Order> orderRepository,
        IUserService userService)
    {
        _deliveryMethodRepository = deliveryMethodRepository;
        _shoppingCartService = shoppingCartService;
        _bookRepository = bookRepository;
        _mapper = mapper;
        _orderRepository = orderRepository;
        _userService = userService;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderRequestVM request)
    {
        var customerBasket = await _shoppingCartService.GetBasketAsync(request.ShoppingCartId)
            ?? throw new ArgumentException("Shoping can not be founded !!!");

        var deliveryMethod = await _deliveryMethodRepository.GetByIdAsync(request.DeliveryMethodId)
            ?? throw new ArgumentException("Delivery Method not founded !!!");

        // initiate order items
        var orderItems = new List<OrderItem>();
        decimal productsTotal = 0m;

        foreach (var basketItem in customerBasket.Value.ShoppingCartItems)
        {
            var product = await _bookRepository.GetByIdAsync(basketItem.ProductId)
                ?? throw new ArgumentException("Product not found.");

            var mappedProduct = _mapper.Map<BookForListVM>(product)
                ?? throw new ArgumentException("Product can not be null.");

            var productItemOrdered = new ProductItemOrdered
            {
                PictureUrl = mappedProduct.PictureUrl,
                ProductName = product.Title!,
                ProductId = product.Id
            };

            var orderItem = new OrderItem
            {
                ProductItemOrdered = productItemOrdered,
                Quantity = basketItem.Quantity,
                UnitPrice = product.Price
            };

            orderItems.Add(orderItem);

            productsTotal += product.Price * basketItem.Quantity;

            //product.StockQuantity -= basketItem.Quantity;

            //_bookRepository.Update(product);

        }


        var order = new Order
        {
            CustomerEmail = _userService.UserEmail,
            CreatedAt = DateTimeOffset.Now,
            DeliveryMethodId = deliveryMethod.Id,
            OrderItems = orderItems,
            OrderStatus = OrderStatus.Pending,
            ShippingAddress = request.ShippingAddress,
            TotalAmount = productsTotal + deliveryMethod.Cost,
            UpdatedAt = DateTimeOffset.Now
        };

        _orderRepository.Add(order);
        return order;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        => await _orderRepository.GetAllAsync();

    public async Task<Order?> GetUserOrderAsync(string customerEmail, int orderId)
    {
        //var allOrders = await _orderRepository.GetAllAsync(); // without specification
        var specification = new GetAllOrdersWithOrderItemsSpecification();
        var allOrders = await _orderRepository.GetAllWithSpecificationAsync(specification);
        var userOrder = allOrders.FirstOrDefault(order =>
            order.CustomerEmail == customerEmail && order.Id == orderId);
        return userOrder;
    }

    public async Task<IEnumerable<Order>> GetUserOrdersAsync(string customerEmail)
    {
        //var allOrders = await _orderRepository.GetAllAsync(); // without specification
        var specification = new GetAllOrdersWithOrderItemsSpecification();
        var allOrders = await _orderRepository.GetAllWithSpecificationAsync(specification);
        var userOrders = allOrders.Where(order => order.CustomerEmail == customerEmail)
            .OrderByDescending(x => x.CreatedAt);
        return userOrders;
    }
}
