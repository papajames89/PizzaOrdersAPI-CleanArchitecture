using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Contracts.Orders
{
    public record OrdersResult(
        List<Order> Orders);
}