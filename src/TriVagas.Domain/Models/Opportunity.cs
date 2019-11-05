using System;
using System.Collections.Generic;
using TriVagas.Domain.Enum;

namespace TriVagas.Domain.Models
{
    public class Opportunity : BaseEntity
    {
        public Opportunity(Company company, 
                           Class _class, 
                           List<Skill> skills, 
                           string description,
                           EJobType jobType,
                           decimal salaryMin,
                           decimal salaryMax,
                           Job job,
                           List<Like> likes,
                           User user)
        {
            LastUpdate = DateTime.Now;
            LastUpdateBy = user;
            CreationDate = DateTime.Now;
            CreatedBy = user;
            Company = company;
            CompanyId = company.Id;
            Class = _class;
            ClassId = _class.Id;
            Skills = skills;
            Description = description;
            JobType = jobType;
            SalaryMin = salaryMin;
            SalaryMax = salaryMax;
            Active = true;
            Job = job;
            Likes = likes;
        }

        // Empty constructor for EF.
        protected Opportunity(){}
        public Company Company { get; private set; }
        public int CompanyId { get; private set; }
        public Class Class { get; private set; }
        public int ClassId { get; private set; }
        public List<Skill> Skills { get; private set; }
        public string Description { get; private set; }
        public EJobType JobType { get; private set; }
        public decimal? SalaryMin { get; private set; }
        public decimal? SalaryMax { get; private set; }
        public bool Active { get; private set; }
        public Job Job { get; private set; }
        public List<Like> Likes { get; private set; }
    }
}
