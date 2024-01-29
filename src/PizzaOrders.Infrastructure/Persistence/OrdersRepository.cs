using MongoDB.Driver;
using PizzaOrders.Application.Common.Interfaces.Persistence;
using PizzaOrders.Contracts.Orders;
using PizzaOrders.Domain.Entities;
using PizzaOrders.Infrastructure.Persistence.MongoDb;

namespace PizzaOrders.Infrastructure.Persistence
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IMongoCollection<Order> _collection;

        public OrdersRepository(IMongoContext mongoContext)
        {
            _collection = mongoContext.GetCollection<Order>("PizzaOrdersDB");
        }
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _collection.Find(FilterDefinition<Order>.Empty).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUserAsync(OrdersByUserRequest request)
        {
            return await _collection.Find(o => o.UserEmail == request.Email).ToListAsync();
        }

        public async Task PostOrderAsync(Order order)
        {
           await _collection.InsertOneAsync(order);
        }

        public async Task DeleteOrderByAsync(Guid id)
        {
            await _collection.DeleteOneAsync(o => o.Id.Equals(id));
        }
    }
}