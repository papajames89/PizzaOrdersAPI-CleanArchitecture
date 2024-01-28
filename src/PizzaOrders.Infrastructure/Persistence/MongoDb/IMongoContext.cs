using MongoDB.Driver;

namespace PizzaOrders.Infrastructure.Persistence.MongoDb
{
    public interface IMongoContext : IDisposable
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}