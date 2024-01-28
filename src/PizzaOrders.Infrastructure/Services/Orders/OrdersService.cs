using PizzaOrders.Application.Common.Interfaces.Persistence;
using PizzaOrders.Application.Services.Orders;
using PizzaOrders.Contracts.Orders;
using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Infrastructure.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<OrdersResult> GetOrdersAsync()
        {
            var orders = await _ordersRepository.GetOrdersAsync();
            if (orders is not List<Order> ordersList)
            {
                throw new Exception("");
            }

            return new OrdersResult(ordersList);
        }
    }
}