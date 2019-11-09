using TriVagas.Domain.Models;
using System;
using System.Threading.Tasks;
using TriVagas.Services.Requests;
using TriVagas.Services.Responses;

namespace TriVagas.Services.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<UserRegisterResponse> Regiser(UserRegisterRequest user);
        Task<UserLoginResponse> Login(UserLoginRequest user);
        Task<bool> GetByEmail(UserRegisterRequest userRequest);
        Task<User> GetById(int id);
    }
}
