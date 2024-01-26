using PizzaOrders.Application.Common.Interfaces.Persistence.Database;

namespace PizzaOrders.Infrastructure.Persistence.MongoDb;

public class MongoDbSettings : IDbSettings
{
    public string? DatabaseName { get; set; }
    public string? ConnectionString { get; set; }
}