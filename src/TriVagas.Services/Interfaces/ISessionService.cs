using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TriVagas.Services.Requests;
using TriVagas.Services.Responses;

namespace TriVagas.Services.Interfaces
{
    public interface ISessionService : IDisposable
    {
        Task<JWTokenResponse> Login(UserLoginRequest user);

        Task<bool> Logout(JWTokenRequest jwtToken);
    }
}
