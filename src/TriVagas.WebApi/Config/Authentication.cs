using System.Threading.Tasks;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Requests;
using TriVagas.Services.Responses;
using TriVagas.Services.Exceptions;
using Microsoft.AspNetCore.Http;

namespace TriVagas.WebApi.Config
{
    public class Authentication
    {
        private readonly IUserService _userService;
        private readonly IJWTService _jwtService;
        private readonly HttpContext _httpContext;

        public Authentication(
            IUserService userService,
            IHttpContextAccessor httpContextAccessor,
            IJWTService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<object> Login(UserLoginRequest credentials)
        {
            var user = await _userService.GetUserByCredentials(credentials.Email, credentials.Password);

            if (user == null) throw new AuthenticationException("Credenciais Inválidas");

            var jwtTokenString = _jwtService.GenerateToken(user);

            var loggedUser = new
            {
                user.Id,
                user.Profile.Name,
                user.Email
            };

            _httpContext.Items["user"] = loggedUser;

            return new AuthenticatedUserResponse() { AccessToken = jwtTokenString, UserId = user.Id, UserName = user.Profile.Name };
        }
    }
}
