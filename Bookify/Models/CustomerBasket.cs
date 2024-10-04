namespace Bookify.Models;

public class CustomerBasket
{
    public string BasketId { get; set; } = null!;
    public List<BasketItem> BasketItems { get; set; } = [];
}
