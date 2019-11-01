using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class User : BaseEntity
    {
        public User(Profile profile, string email, string password)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = this;
            CreationDate = DateTime.Now;
            CreatedBy = this;
            Profile = profile;
            Email = email;
            Password = password;
        }

        // Empty constructor for EF.
        protected User() { }
        public Profile Profile { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public int? ProfileId { get; private set; }

        // M - N Relationships
        public List<CompanyUser> CompaniesEmployees { get; private set; }
        public List<PageUser> PageOwners { get; private set; }

    }
}
