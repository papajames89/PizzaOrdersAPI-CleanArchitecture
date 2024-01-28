namespace PizzaOrders.Application.Common.Interfaces.Persistence.Database
{
    public interface IDbSettings
    {
        string? DatabaseName { get; set; }
        string? ConnectionString { get; set; }
    }
}