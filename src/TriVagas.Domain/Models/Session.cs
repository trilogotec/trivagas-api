using System;
using System.Collections.Generic;
using System.Text;

namespace TriVagas.Domain.Models
{
    public class Session
    {
        public Session(User user, string sessionToken)
        {
            User = user;
        }

        protected Session() { }

        public string SessionToken { get; protected set; }
        
        public User User { get; protected set; }
    }
}
