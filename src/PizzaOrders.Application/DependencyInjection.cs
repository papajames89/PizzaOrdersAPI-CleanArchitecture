using Microsoft.Extensions.DependencyInjection;
using PizzaOrders.Application.Services.Authentication;

namespace PizzaOrders.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}