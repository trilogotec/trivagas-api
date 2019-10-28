namespace TriVagas.Domain.Models
{
    public class Like : BaseEntity
    {
        public int OpportunityId { get; private set; }
        public Opportunity Opportunity { get; private set; }
    }
}
