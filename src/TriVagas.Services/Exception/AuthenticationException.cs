using System;

namespace TriVagas.Services.Exceptions
{
    public class AuthenticationException: Exception
    {
        public AuthenticationException(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
