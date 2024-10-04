namespace Bookify.Entities.OrderAggregate;

public class OrderItem : BaseEntity
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
}