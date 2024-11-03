namespace Bookify.Entities.OrderAggregate;

public class DeliveryMethod : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public decimal Cost { get; set; }
}
