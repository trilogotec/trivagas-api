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
        Task<User> GetByEmail(string email);
        Task<User> GetById(int id);
    }
}
