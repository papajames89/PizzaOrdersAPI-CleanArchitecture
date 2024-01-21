using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token);
}