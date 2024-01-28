using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Application.Common.Interfaces.Persistence
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetOrdersAsync();
    }
}