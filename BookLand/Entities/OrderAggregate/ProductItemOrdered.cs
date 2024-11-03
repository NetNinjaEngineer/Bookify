namespace Bookify.Entities.OrderAggregate;

public class ProductItemOrdered
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string? PictureUrl { get; set; } = string.Empty;
}
