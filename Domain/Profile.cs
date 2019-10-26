using System;
using System.Collections.Generic;

namespace Domain
{
    public class Profile : BaseEntity
    {
        public string Name { get; set; }
        public City City { get; set; }
        public Class Class { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Job> Experience { get; set; }
        public string GitHub { get; set; }
        public string LinkedIn { get; set; }
        public int Contribution { get; set; }
    }
}
