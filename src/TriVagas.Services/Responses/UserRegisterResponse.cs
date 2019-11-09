using Microsoft.IdentityModel.Tokens;

namespace TriVagas.Services.Responses
{
    public class UserRegisterResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}