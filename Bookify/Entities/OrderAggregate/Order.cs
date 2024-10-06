namespace Bookify.Entities.OrderAggregate;

public class Order : BaseEntity
{
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

    public ShippingAddress ShippingAddress { get; set; } = null!;

    public int DeliveryMethodId { get; set; }

    public DeliveryMethod DeliveryMethod { get; set; } = null!;

    public string CustomerEmail { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int TotalAmount { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = [];

}
