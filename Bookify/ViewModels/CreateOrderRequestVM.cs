using Bookify.Entities.OrderAggregate;
using System.ComponentModel.DataAnnotations;

namespace Bookify.ViewModels;

public class CreateOrderRequestVM
{
    [Required]
    public int DeliveryMethodId { get; set; }

    [Required]
    public Guid ShoppingCartId { get; set; }

    public ShippingAddress ShippingAddress { get; set; } = null!;
}
