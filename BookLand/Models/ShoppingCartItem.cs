namespace Bookify.Models;

public class ShoppingCartItem
{
    public Guid Id { get; set; }

    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? PictureUrl { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public DateTimeOffset AddedAt { get; set; }
}
