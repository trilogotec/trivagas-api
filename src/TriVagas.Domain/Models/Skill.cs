using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }

        public int OpportunityId { get; private set; }
        public Opportunity  Opportunity { get; private set; }
    }
}
