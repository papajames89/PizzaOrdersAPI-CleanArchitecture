using PizzaOrders.Domain.Primitives;

namespace PizzaOrders.Domain.Entities
{
    public sealed class User : Entity
    {
        public User(Guid id, string firstName, string lastName, string email, string password) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}