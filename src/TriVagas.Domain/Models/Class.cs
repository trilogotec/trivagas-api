using System.Collections.Generic;

namespace TriVagas.Domain.Models
{
    public class Class : BaseEntity
    {
        public string Name { get; private set; }
        public List<Opportunity> Opportunities { get; private set; }
    }
}
