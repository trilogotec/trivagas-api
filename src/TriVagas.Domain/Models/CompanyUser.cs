namespace TriVagas.Domain.Models
{
    public class CompanyUser
    {
        public CompanyUser(Company company, User employee)
        {
            Company = company;
            Employee = employee;
        }

        protected CompanyUser() { }
        public int CompanyId { get; protected set; }
        public Company Company { get; protected set; }

        public int EmployeeId { get; protected set; }
        public User Employee { get; protected set; }
    }
}