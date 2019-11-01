namespace TriVagas.Domain.Models
{
    public class CompanyUser
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int EmployeeId { get; set; }
        public User Employee { get; set; }
    }
}