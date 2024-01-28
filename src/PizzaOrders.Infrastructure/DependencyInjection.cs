using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaOrders.Application.Common.Interfaces.Authentication;
using PizzaOrders.Application.Common.Interfaces.Persistence;
using PizzaOrders.Application.Common.Interfaces.Services;
using PizzaOrders.Application.Services.Authentication;
using PizzaOrders.Application.Services.Orders;
using PizzaOrders.Infrastructure.Authentication;
using PizzaOrders.Infrastructure.Persistence;
using PizzaOrders.Infrastructure.Persistence.MongoDb;
using PizzaOrders.Infrastructure.Services;
using PizzaOrders.Infrastructure.Services.Authentication;
using PizzaOrders.Infrastructure.Services.Orders;

namespace PizzaOrders.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager builderConfiguration)
        {
            services.Configure<JwtSettings>(builderConfiguration.GetSection(JwtSettings.SectionName));
            services.Configure<JwtValidationParameters>(
                builderConfiguration.GetSection(JwtValidationParameters.SectionName));
            services.ConfigureOptions<JwtBearerOptionsSetup>();

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IOrdersService, OrdersService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddMongoDbRepository(builderConfiguration);

            return services;
        }
    }
}