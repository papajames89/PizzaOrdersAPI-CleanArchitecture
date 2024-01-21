using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaOrders.Application.Common.Interfaces.Authentication;
using PizzaOrders.Application.Common.Interfaces.Persistence;
using PizzaOrders.Application.Common.Interfaces.Services;
using PizzaOrders.Infrastructure.Authentication;
using PizzaOrders.Infrastructure.Persistence;
using PizzaOrders.Infrastructure.Services;

namespace PizzaOrders.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager builderConfiguration)
        {
            services.Configure<JwtSettings>(builderConfiguration.GetSection(JwtSettings.SectionName));
            
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}