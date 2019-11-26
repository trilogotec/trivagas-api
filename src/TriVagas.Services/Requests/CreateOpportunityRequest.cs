using TriVagas.Domain.Enum;

namespace TriVagas.Services.Requests
{
    public class CreateOpportunityRequest
    {
        public string Title { get; set; }
        public int CompanyId { get; set; }
        public int ClassId { get; set; }
        public string Description { get; set; }
        public EJobType JobType { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
    }
}
