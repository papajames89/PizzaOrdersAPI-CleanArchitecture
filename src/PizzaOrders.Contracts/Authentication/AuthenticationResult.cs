using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Contracts.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token);
}