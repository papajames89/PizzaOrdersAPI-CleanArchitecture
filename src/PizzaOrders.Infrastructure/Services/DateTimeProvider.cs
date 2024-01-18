using PizzaOrders.Application.Common.Interfaces.Services;

namespace PizzaOrders.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.Now;
    }
}