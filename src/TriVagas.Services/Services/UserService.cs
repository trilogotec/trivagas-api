using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IJWTService _jwtService;

        public UserService(IUserRepository userRepository, IJWTService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<User> GetById(int id) 
        {
            return await _userRepository.GetById(id);
        } 

        public async Task<UserRegisterResponse> Regiser(UserRegisterRequest userRequest)
        {
            var user = new User(userRequest.Email, userRequest.Password);
            var registeredUser = await _userRepository.Add(user);
            var jwtTokenString = _jwtService.GenerateToken(registeredUser);
            return new UserRegisterResponse {Email = registeredUser.Email, Token = jwtTokenString };
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}