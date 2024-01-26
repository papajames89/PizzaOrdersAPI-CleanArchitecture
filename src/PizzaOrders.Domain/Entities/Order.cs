using PizzaOrders.Domain.Primitives;

namespace PizzaOrders.Domain.Entities;

public sealed class Order : Entity
{
    public Order(Guid id, User user, string pizzaName, List<string> ingredients, DateTime orderDate) : base(id)
    {
        User = user;
        PizzaName = pizzaName;
        Ingredients = ingredients;
        OrderDate = orderDate;
    }

    public User User { get; set; }
    public string PizzaName { get; set; }
    public List<string> Ingredients { get; set; }
    public DateTime OrderDate { get; set; }
}