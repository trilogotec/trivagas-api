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
        
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        
        public Opportunity Opportunity { get; private set; }
        public int OpportunityId { get; private set; }
    }
}
