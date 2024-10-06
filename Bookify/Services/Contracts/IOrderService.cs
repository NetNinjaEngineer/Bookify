using Bookify.Entities.OrderAggregate;
using Bookify.ViewModels;

namespace Bookify.Services.Contracts;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(CreateOrderRequestVM request);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<IEnumerable<Order>> GetUserOrdersAsync(string customerEmail);
    Task<Order?> GetUserOrderAsync(string customerEmail, int orderId);
}
