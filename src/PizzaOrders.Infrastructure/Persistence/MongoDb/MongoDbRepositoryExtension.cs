using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PizzaOrders.Application.Common.Interfaces.Persistence.Database;

namespace PizzaOrders.Infrastructure.Persistence.MongoDb
{
    public static class MongoDbRepositoryExtension
    {
        public static void AddMongoDbRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoDbClient, MongoDbClient>();
            services.AddTransient<IMongoContext, MongoContext>();
            services.Configure<MongoDbSettings>(configuration.GetSection("PizzaOrdersDatabaseSettings"));
            services.AddSingleton<IDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }
    }
}