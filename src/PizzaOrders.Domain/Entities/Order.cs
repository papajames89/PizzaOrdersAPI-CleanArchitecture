using PizzaOrders.Domain.Primitives;

namespace PizzaOrders.Domain.Entities
{
    public sealed class Order : Entity
    {
        public Order(Guid id, string userEmail, string pizzaName, List<string> ingredients, DateTime orderDate) : base(id)
        {
            UserEmail = userEmail;
            PizzaName = pizzaName;
            Ingredients = ingredients;
            OrderDate = orderDate;
        }

        public string UserEmail { get; set; }
        public string PizzaName { get; set; }
        public List<string> Ingredients { get; set; }
        public DateTime OrderDate { get; set; }
    }
}