using MongoDB.Driver;
using PizzaOrders.Application.Common.Interfaces.Persistence;
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
            var result = await _collection.Find(FilterDefinition<Order>.Empty).ToListAsync();

            return result;
        }
    }
}