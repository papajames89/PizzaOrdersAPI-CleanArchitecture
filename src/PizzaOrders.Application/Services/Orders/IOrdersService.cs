using PizzaOrders.Contracts.Orders;

namespace PizzaOrders.Application.Services.Orders
{
    public interface IOrdersService
    {
        Task<OrdersResult> GetOrdersAsync();
        Task<OrdersResult> GetOrdersByUserAsync(OrdersByUserRequest request);
        Task<OrderResult> PostOrderAsync(OrderRequest order);
    }
}