using PizzaOrders.Contracts.Orders;
using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Application.Common.Interfaces.Persistence
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task<List<Order>> GetOrdersByUserAsync(OrdersByUserRequest request);
        Task PostOrderAsync(Order order);
        Task DeleteOrderByAsync(Guid id);
    }
}