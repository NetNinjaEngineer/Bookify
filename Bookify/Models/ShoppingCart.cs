namespace Bookify.Models;

public class ShoppingCart
{
    public Guid BasketId { get; set; }

    public string CustomerEmail { get; set; } = string.Empty;

    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = [];

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}
