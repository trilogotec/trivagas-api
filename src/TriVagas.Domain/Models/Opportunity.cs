using System;
using System.Collections.Generic;
using TriVagas.Domain.Enum;

namespace TriVagas.Domain.Models
{
    public class Opportunity : BaseEntity
    {
        public Opportunity(string title,
                           int companyId, 
                           int _classId, 
                           string description,
                           EJobType jobType,
                           decimal salaryMin,
                           decimal salaryMax,
                           int userId)
        {
            LastUpdate = DateTime.Now;
            LastUpdateById = userId;
            CreationDate = DateTime.Now;
            CreatedById = userId;
            Title = title;
            CompanyId = companyId;
            ClassId = _classId;
            Description = description;
            JobType = jobType;
            SalaryMin = salaryMin;
            SalaryMax = salaryMax;
            Active = true;
        }

        // Empty constructor for EF.
        protected Opportunity(){}

        public string Title { get; protected set; }
        public Company Company { get; protected set; }
        public int CompanyId { get; protected set; }
        public Class Class { get; protected set; }
        public int ClassId { get; protected set; }
        public List<Skill> Skills { get; protected set; }
        public string Description { get; protected set; }
        public EJobType JobType { get; protected set; }
        public decimal SalaryMin { get; protected set; }
        public decimal SalaryMax { get; protected set; }
        public bool Active { get; protected set; }
        public Job Job { get; protected set; }
        public List<Like> Likes { get; protected set; }
    }
}
