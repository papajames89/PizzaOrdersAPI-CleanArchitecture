using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaOrders.Application.Services.Orders;
using PizzaOrders.Contracts.Orders;

namespace PizzaOrders.API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
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

        [HttpGet("get-orders")]
        public async Task<IActionResult> Get()
        {
            var result = await _ordersService.GetOrdersAsync();

            return Ok(result);
        }
    }
}