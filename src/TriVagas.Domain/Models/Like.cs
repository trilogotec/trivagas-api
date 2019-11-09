using System;

namespace TriVagas.Domain.Models
{
    public class Like : BaseEntity
    {
        public Like(User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
        }

        // Empty constructor for EF.
        protected Like() { }

        public int OpportunityId { get; protected set; }
        public Opportunity Opportunity { get; protected set; }
    }
}
