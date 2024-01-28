using PizzaOrders.Application.Common.Interfaces.Authentication;
using PizzaOrders.Application.Common.Interfaces.Persistence;
using PizzaOrders.Application.Services.Authentication;
using PizzaOrders.Contracts.Authentication;
using PizzaOrders.Domain.Entities;

namespace PizzaOrders.Infrastructure.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Register(string firstName, string lastName, string email,
            string password)
        {
            // Check if user already exists
            var existingUser = await _userRepository.GetUserByEmailAsync(email);
            if (existingUser is not null)
            {
                throw new Exception("User with given email already exists!");
            }

            // Create user (generate unique ID)
            var user = new User(Guid.NewGuid(), firstName, lastName, email, password);
            await _userRepository.Add(user);


            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public async Task<AuthenticationResult> Login(string email, string password)
        {
            // Validate the user exists
            var existingUser = await _userRepository.GetUserByEmailAsync(email);
            if (existingUser is not User user)
            {
                throw new Exception("Invalid credentials!");
            }

            // Validate the password is correct
            if (user.Password != password)
            {
                throw new Exception("Invalid credentials!");
            }

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}