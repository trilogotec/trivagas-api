using System;
using System.Collections.Generic;
using System.Text;

namespace TriVagas.Services.Responses
{
    public class AuthenticatedUserResponse
    {
        public string AccessToken { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
