using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PizzaOrders.Application.Services.Authentication;
using PizzaOrders.Contracts.Authentication;

namespace PizzaOrders.API.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var authResult = await _authenticationService.RegisterAsync(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var authResult = await _authenticationService.LoginAsync(
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);

            return Ok(response);
        }
    }
}