using MongoDB.Driver;
using PizzaOrders.Application.Common.Interfaces.Persistence.Database;

namespace PizzaOrders.Infrastructure.Persistence.MongoDb
{
    public interface IMongoDbClient
    {
        IMongoDatabase MongoDatabase { get; }
    }
    public class MongoDbClient: IMongoDbClient
    {
        public IMongoDatabase MongoDatabase { get; }
        public MongoDbClient(IDbSettings settings) {

            MongoDatabase = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        }
    }
}