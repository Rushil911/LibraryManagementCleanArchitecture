using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;


namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await _userRepository.GetByUsername(username);

            if (user == null)
                throw new Exception("Invalid credentials");

            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!isValid)
                throw new Exception("Invalid credentials");

            return _tokenService.GenerateToken(user);
        }

        public Task<string> LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
