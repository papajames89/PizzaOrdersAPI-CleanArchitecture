using PizzaOrders.Contracts.Orders;

namespace PizzaOrders.Application.Services.Orders
{
    public interface IOrdersService
    {
        Task<OrdersResult> GetOrdersAsync();
    }
}