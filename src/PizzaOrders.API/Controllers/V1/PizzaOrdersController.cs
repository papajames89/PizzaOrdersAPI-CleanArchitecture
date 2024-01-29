using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PizzaOrders.Application.Services.Orders;
using PizzaOrders.Contracts.Orders;

namespace PizzaOrders.API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/pizza-orders")]
    [Authorize]
    [ApiController]
    [ApiVersion(1.0)]
    public class PizzaOrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public PizzaOrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost("post-order")]
        public async Task<IActionResult> PostOrder(OrderRequest order)
        {
            var result = await _ordersService.PostOrderAsync(order);

            return Ok(result);
        }

        [HttpGet("get-orders")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _ordersService.GetOrdersAsync();

            return Ok(result);
        }

        [HttpGet("get-orders-by-user")]
        public async Task<IActionResult> GetOrdersByUser(OrdersByUserRequest request)
        {
            var result = await _ordersService.GetOrdersByUserAsync(request);

            return Ok(result);
        }

        [HttpDelete("delete-order-by-id")]
        public async Task<IActionResult> DeleteOrder()
        {
            Request.Headers.TryGetValue("order-Id", out var requestOrderId);
            if (requestOrderId.FirstOrDefault().IsNullOrEmpty()) return BadRequest("Order id not provided!");

            if (!Guid.TryParse(requestOrderId, out var orderId)) return BadRequest("Invalid order id in the header!");

            await _ordersService.DeleteOrderByIdAsync(orderId);

            return Ok($"Order with id: {orderId}, successfully deleted");
        }
    }
}