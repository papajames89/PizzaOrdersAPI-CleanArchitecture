using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace PizzaOrders.Infrastructure.Persistence.MongoDb
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase? Database { get; set; }
        public IClientSessionHandle? Session { get; set; }
        private MongoClient? MongoClient { get; set; }
        private readonly IConfiguration _configuration;

        public MongoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
            {
                return;
            }

            // Configure mongo (You can inject the config, just to simplify)
            MongoClient = new MongoClient(_configuration["PizzaOrdersDatabaseSettings:ConnectionString"]);

            Database = MongoClient.GetDatabase(_configuration["PizzaOrdersDatabaseSettings:DatabaseName"]);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();

            return Database?.GetCollection<T>(name)!;
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}