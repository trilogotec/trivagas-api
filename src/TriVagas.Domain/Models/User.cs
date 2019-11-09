using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class User : BaseEntity
    {
        public User(string email, string password)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = null;
            CreationDate = DateTime.Now;
            CreatedBy = null;
            Email = email;
            Password = password;
        }

        // Empty constructor for EF.
        protected User() { }
        public Profile Profile { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        public int? ProfileId { get; protected set; }

        // M - N Relationships
        public List<CompanyUser> CompaniesEmployees { get; protected set; }
        public List<PageUser> PageOwners { get; protected set; }

    }
}
