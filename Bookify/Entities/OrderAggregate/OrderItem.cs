namespace Bookify.Entities.OrderAggregate;

public class OrderItem : BaseEntity
{
    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public ProductItemOrdered ProductItemOrdered { get; set; } = null!;

}
