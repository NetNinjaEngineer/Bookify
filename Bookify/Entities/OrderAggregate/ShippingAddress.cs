using System.ComponentModel.DataAnnotations;

namespace Bookify.Entities.OrderAggregate;

public class ShippingAddress
{
    [Required]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Required]
    [StringLength(100)]
    public string ShippingAddressLine1 { get; set; } = string.Empty;

    [StringLength(100)]
    public string ShippingAddressLine2 { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string ShippingCity { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string ShippingState { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string ShippingPostalCode { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string ShippingCountry { get; set; } = string.Empty;
}