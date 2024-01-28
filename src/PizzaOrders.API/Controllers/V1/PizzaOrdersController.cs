using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaOrders.Application.Services.Orders;
using PizzaOrders.Contracts.Orders;
using PizzaOrders.Domain.Entities;

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
    }
}