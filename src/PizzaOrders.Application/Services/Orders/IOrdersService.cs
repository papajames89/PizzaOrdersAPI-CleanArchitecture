using PizzaOrders.Contracts.Orders;
using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Application.Services.Orders
{
    public interface IOrdersService
    {
        Task<OrdersResult> GetOrdersAsync();
        Task<OrderResult> PostOrderAsync(OrderRequest order);
    }
}