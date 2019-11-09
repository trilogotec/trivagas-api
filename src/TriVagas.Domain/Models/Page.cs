using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class Page : BaseEntity
    {
        public Page(Company company, User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
            Company = company;
        }

        // Empty constructor for EF.
        protected Page() { }

        public Company Company { get; protected set; }
        public List<PageUser> PageOwners { get; protected set; }
    }
}
