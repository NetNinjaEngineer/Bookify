using Bookify.Entities.OrderAggregate;

namespace Bookify.ViewModels;

public class OrderForListVM
{
    public OrderStatus OrderStatus { get; set; }

    public ShippingAddress ShippingAddress { get; set; } = null!;

    public string DeliveryMethod { get; set; } = string.Empty;

    public string CustomerEmail { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public decimal TotalAmount { get; set; }

    public ICollection<OrderItemForListVM> OrderItems { get; set; } = [];
}
