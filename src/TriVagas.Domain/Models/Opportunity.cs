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
        public Company Company { get; protected set; }
        public int CompanyId { get; protected set; }
        public Class Class { get; protected set; }
        public int ClassId { get; protected set; }
        public List<Skill> Skills { get; protected set; }
        public string Description { get; protected set; }
        public EJobType JobType { get; protected set; }
        public decimal? SalaryMin { get; protected set; }
        public decimal? SalaryMax { get; protected set; }
        public bool Active { get; protected set; }
        public Job Job { get; protected set; }
        public List<Like> Likes { get; protected set; }
    }
}
