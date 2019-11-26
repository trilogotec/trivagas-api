using System.Collections.Generic;
using System.Security.Claims;
using TriVagas.Domain.Models;

namespace TriVagas.Services.Interfaces
{
    public interface IJWTService
    {
        bool IsTokenValid(string token);

        public string GenerateToken(User user);

        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
