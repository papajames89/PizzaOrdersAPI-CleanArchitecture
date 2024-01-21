using System.Reflection.Metadata;
using PizzaOrders.Application.Common.Interfaces.Persistence;
using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        // TODO remove in further development, connect with database
        private static readonly List<User> _users = new();

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}