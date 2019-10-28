using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public City City { get; set; }
        public string LinkedIn { get; set; }
        public List<User> Employees { get; set; }

        public List<Opportunity> Opportunities { get; set; }
    }
}
