using Bookify.Entities.OrderAggregate;

namespace Bookify.Data.DataSeed;

public static class DeliveryMethodsSeed
{
    public static List<DeliveryMethod> GetDeliveryMethods()
    {
        return
        [
            new DeliveryMethod
            {
                Title = "Standard Shipping",
                Cost = 5.99m
            },
            new DeliveryMethod
            {
                Title = "Express Shipping",
                Cost = 12.99m
            },
            new DeliveryMethod
            {
                Title = "Next-Day Delivery",
                Cost = 19.99m
            },
            new DeliveryMethod
            {
                Title = "International Shipping",
                Cost = 29.99m
            },
            new DeliveryMethod
            {
                Title = "Free Shipping",
                Cost = 0.00m
            }
        ];
    }
}