namespace Bookify.Entities.OrderAggregate;

public class OrderItem : BaseEntity
{
    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public ProductItemOrdered ProductItemOrdered { get; set; } = null!;

}
