using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}