using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task Add(User user);
    }
}