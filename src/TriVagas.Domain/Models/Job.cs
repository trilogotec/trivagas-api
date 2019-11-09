using System;

namespace TriVagas.Domain.Models
{
    public class Job : BaseEntity
    {
        public Job(Profile profile, 
                   Company company, 
                   Position position, 
                   DateTime startDate, 
                   string description,
                   User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
            Profile = profile;
            Company = company;
            Position = position;
            StartDate = startDate;
            Description = description;
        }

        // Empty constructor for EF.
        protected Job() { }
        
        public Profile Profile { get; protected set; }
        public int ProfileId { get; protected set; }
        public Company Company { get; protected set; }
        public int CompanyId { get; protected set; }
        public Position Position { get; protected set; }
        public int PositionId { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }
        public string Description { get; protected set; }

        
        public Opportunity Opportunity { get; protected set; }
        public int OpportunityId { get; protected set; }
    }
}
