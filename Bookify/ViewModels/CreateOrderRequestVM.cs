using Bookify.Entities.OrderAggregate;
using System.ComponentModel.DataAnnotations;

namespace Bookify.ViewModels;

public class CreateOrderRequestVM
{
    [Required]
    [EmailAddress]
    public string CustomerEmail { get; set; } = string.Empty;

    [Required]
    public int DeliveryMethodId { get; set; }

    [Required]
    public Guid ShoppingCartId { get; set; }

    public ShippingAddress ShippingAddress { get; set; } = null!;
}
