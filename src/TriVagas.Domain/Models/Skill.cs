using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class Skill : BaseEntity
    {
        public Skill(string name, User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
            Name = name;
        }

        // Empty constructor for EF.
        protected Skill() { }

        public string Name { get; protected set; }

        public int OpportunityId { get; protected set; }
        public Opportunity  Opportunity { get; protected set; }
    }
}
