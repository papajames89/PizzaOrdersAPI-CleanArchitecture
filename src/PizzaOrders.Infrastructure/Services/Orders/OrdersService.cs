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
            var ordersResult = await _ordersRepository.GetOrdersAsync();
            if (ordersResult is not List<Order> ordersList)
            {
                throw new Exception("Wrong type of result!");
            }

            return new OrdersResult(ordersList);
        }

        public async Task<OrdersResult> GetOrdersByUserAsync(OrdersByUserRequest request)
        {
            var ordersResult = await _ordersRepository.GetOrdersByUserAsync(request);
            if (ordersResult is not List<Order> orders)
            {
                throw new Exception();
            }

            return new OrdersResult(orders);
        }

        public async Task<OrderResult> PostOrderAsync(OrderRequest orderRequest)
        {
            var order = new Order(Guid.NewGuid(), orderRequest.UserEmail, orderRequest.PizzaName, orderRequest.Ingredients,
                orderRequest.OrderDate);
            await _ordersRepository.PostOrderAsync(order);

            return new OrderResult(order);
        }
    }
}