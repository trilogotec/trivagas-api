using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Requests;
using TriVagas.Services.Responses;


namespace TriVagas.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHostEnvironment _env;
        private readonly IConfigurationRoot _config;
        public UserService(IUserRepository userRepository, IHostEnvironment env)
        {
            _userRepository = userRepository;
            _env = env;

            _config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json")
                .Build();
        }

        public async Task<UserRegisterResponse> Regiser(UserRegisterRequest userRequest)
        {
            var user = new User(userRequest.Email, userRequest.Password);
            var registeredUser = await _userRepository.Add(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _config.GetSection("AppSettings").GetSection("Secret").Value;
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userToken = tokenHandler.WriteToken(token);
            return new UserRegisterResponse {Email = registeredUser.Email, Token = userToken};
        }
        public async Task<UserLoginResponse> Login(UserLoginRequest user)
        {
            var userLogin = await _userRepository.Login(user.Email, user.Password);
            if (userLogin == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _config.GetSection("AppSettings").GetSection("Secret").Value;
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, userLogin.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userToken = tokenHandler.WriteToken(token);
            return new UserLoginResponse {Email = userLogin.Email, Token = userToken};
        }

        public async Task<bool> GetByEmail(UserRegisterRequest userRequest)
        {
            return await _userRepository.GetByEmail(userRequest.Email) != null;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}