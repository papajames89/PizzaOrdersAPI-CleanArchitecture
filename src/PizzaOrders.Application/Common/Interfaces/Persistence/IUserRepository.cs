using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}