using System;
using System.Collections.Generic;

namespace Domain
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public City City { get; set; }
        public string LinkedIn { get; set; }
        public List<User> Employees  { get; set; }
    }
}
