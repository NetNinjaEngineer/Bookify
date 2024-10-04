namespace Bookify.Entities.OrderAggregate;

public class OrderItem : BaseEntity
{
    public ProductItemOrdered ProductItemOrdered { get; set; }
    public decimal Price { get; set; }
}
