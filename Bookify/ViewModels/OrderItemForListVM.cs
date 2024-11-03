using Bookify.Entities.OrderAggregate;

namespace Bookify.ViewModels;

public class OrderItemForListVM
{
    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public ProductItemOrdered ProductItemOrdered { get; set; } = null!;
}
