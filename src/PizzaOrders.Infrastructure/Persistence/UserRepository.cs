using MongoDB.Driver;
using PizzaOrders.Application.Common.Interfaces.Persistence;
using PizzaOrders.Domain.Entities;
using PizzaOrders.Infrastructure.Persistence.MongoDb;

namespace PizzaOrders.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(IMongoContext mongoContext)
        {
            _collection = mongoContext.GetCollection<User>("UsersDB");
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            var result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        public async Task Add(User user)
        {
            await _collection.InsertOneAsync(user);
        }
    }
}