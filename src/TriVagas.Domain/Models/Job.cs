using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class Job : BaseEntity
    {
        public Profile Profile { get; set; }
        public Company Company { get; set; }
        public Position Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        public Opportunity Opportunity { get; private set; }
        public int OpportunityId { get; private set; }
    }
}
