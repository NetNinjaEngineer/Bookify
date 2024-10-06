using Bookify.Entities.OrderAggregate;

namespace Bookify.Specifications;

public class GetAllOrdersWithOrderItemsSpecification : BaseSpecification<Order>
{
    public GetAllOrdersWithOrderItemsSpecification()
    {
        AddIncludes([order => order.OrderItems, order => order.DeliveryMethod]);
    }
}
