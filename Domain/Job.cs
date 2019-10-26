using System;
using System.Collections.Generic;

namespace Domain
{
    public class Job : BaseEntity
    {
        public Profile Profile { get; set; }
        public Company Company { get; set; }
        public Position Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}
