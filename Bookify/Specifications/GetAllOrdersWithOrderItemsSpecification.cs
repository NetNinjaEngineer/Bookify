using Bookify.Entities.OrderAggregate;

namespace Bookify.Specifications;

public class GetAllOrdersWithOrderItemsSpecification : BaseSpecification<Order>
{
    public GetAllOrdersWithOrderItemsSpecification()
    {
        AddIncludes(order => order.OrderItems);
        AddIncludes(order => order.OrderItems);
        AddIncludes(order => order.DeliveryMethod);

    }
}
