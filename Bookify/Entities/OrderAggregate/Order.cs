namespace Bookify.Entities.OrderAggregate;

public class Order : BaseEntity
{
    public string BuyerEmail { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    public ICollection<OrderItem> Items { get; set; } = [];
}
