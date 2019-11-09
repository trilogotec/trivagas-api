using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class Class : BaseEntity
    {
        public Class(string name, User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
            Name = name;
        }

        // Empty constructor for EF.
        protected Class() { }

        public string Name { get; protected set; }
        public List<Opportunity> Opportunities { get; protected set; }
    }
}
