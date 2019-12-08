using System;
using TriVagas.Domain.Enum;
using TriVagas.Domain.Models;

namespace TriVagas.Services.Responses
{
    public class OpportunityResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EJobType JobType { get; set; }
        public UserResponse CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public UserResponse LastUpdateBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public CompanyResponse Company { get; set; }
        public ClassResponse Class { get; set; }
    }
}
