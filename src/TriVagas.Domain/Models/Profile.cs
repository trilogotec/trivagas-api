using System;
using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class Profile : BaseEntity
    {
        public Profile(string name,
                       City city,
                       Class _class,
                       List<Skill> skills,
                       List<Job> experiences,
                       string gitHub,
                       string linkedIn,
                       int contribution,
                       User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
            Name = name;
            City = city;
            Class = _class;
            Skills = skills;
            Experience = experiences;
            GitHub = gitHub;
            LinkedIn = linkedIn;
            Contribution = contribution;
        }

        // Empty constructor for EF.
        protected Profile(){}
        public string Name { get; set; }
        public City City { get; set; }
        public Class Class { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Job> Experience { get; set; }
        public string GitHub { get; set; }
        public string LinkedIn { get; set; }
        public int Contribution { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
