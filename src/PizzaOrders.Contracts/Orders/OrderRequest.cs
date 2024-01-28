using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Contracts.Orders
{
    public record OrderRequest(
        string UserEmail,
        string PizzaName,
        List<string> Ingredients,
        DateTime OrderDate);
}