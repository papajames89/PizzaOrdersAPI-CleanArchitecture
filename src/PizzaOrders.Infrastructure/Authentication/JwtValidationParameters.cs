namespace PizzaOrders.Infrastructure.Authentication
{
    public class JwtValidationParameters
    {
        public const string SectionName = "JwtValidationParameters";
        public bool ValidateLifetime { get; init; }
        public bool ValidateAudience { get; init; }
        public bool ValidateIssuer { get; init; }
    }
}