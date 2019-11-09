using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class Company : BaseEntity
    {
        public Company(string name, City city, string linkedIn, User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
            Name = name;
            City = city;
            LinkedIn = linkedIn;
        }

        // Empty constructor for EF.
        protected Company() { }

        public string Name { get; protected set; }
        public City City { get; protected set; }
        public string LinkedIn { get; protected set; }
        public List<CompanyUser> CompanyEmployees { get; protected set; }

        public List<Opportunity> Opportunities { get; protected set; }
        public List<Job> Jobs { get; protected set; }
    }
}
