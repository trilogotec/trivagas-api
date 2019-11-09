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
        public string Name { get; protected set; }
        public City City { get; protected set; }
        public Class Class { get; protected set; }
        public List<Skill> Skills { get; protected set; }
        public List<Job> Experience { get; protected set; }
        public string GitHub { get; protected set; }
        public string LinkedIn { get; protected set; }
        public int Contribution { get; protected set; }

        public int UserId { get; protected set; }
        public User User { get; protected set; }
    }
}
