using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using TriVagas.Domain.Interfaces;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Requests;
using TriVagas.Services.Responses;

namespace TriVagas.Services.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;

        public SessionService(
            ISessionRepository sessionRepository,
            IUserRepository userRepository,
            IHostEnvironment env,
            IJWTService jwtService)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<JWTokenResponse> Login(UserLoginRequest user)
        {
            var userLogin = await _userRepository.Login(user.Email, user.Password);
            if (userLogin == null) return null;

            var jwtTokenString = _jwtService.GenerateToken(userLogin);

            return new JWTokenResponse() { JwtToken = jwtTokenString };
        }

        public Task<bool> Logout(JWTokenRequest jwtToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
