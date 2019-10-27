using System;
using System.Collections.Generic;
using TriVagas.Domain.Enum;

namespace TriVagas.Domain
{
    public class Opportunity : BaseEntity
    {
        public Company Company { get; set; }
        public Class Class { get; set; }
        public List<Skill> Skills { get; set; }
        public string Description { get; set; }
        public EJobType JobType { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public bool Active { get; set; }
        public Job Job { get; set; }
        public List<Like> Likes { get; set; }
    }
}
