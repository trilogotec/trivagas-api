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

        public string Name { get; set; }
        public City City { get; set; }
        public string LinkedIn { get; set; }
        public List<CompanyUser> CompanyEmployees { get; private set; }

        public List<Opportunity> Opportunities { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
