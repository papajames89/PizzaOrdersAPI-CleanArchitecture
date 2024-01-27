using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace PizzaOrders.Infrastructure.Authentication
{
    public class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtSettings _jwtSettings;
        private readonly JwtValidationParameters _jwtValidation;

        public JwtBearerOptionsSetup(IOptions<JwtSettings> jwtOptions, IOptions<JwtValidationParameters> jwtValidation)
        {
            _jwtSettings = jwtOptions.Value;
            _jwtValidation = jwtValidation.Value;
        }

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateLifetime = _jwtValidation.ValidateLifetime,
                ValidateAudience = _jwtValidation.ValidateAudience,
                ValidateIssuer = _jwtValidation.ValidateIssuer,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
                ClockSkew = Debugger.IsAttached ? TimeSpan.Zero : TimeSpan.FromMinutes(10)
            };
        }
        
        public void Configure(string? name, JwtBearerOptions options)
        {
            Configure(options);
        }
    }
}