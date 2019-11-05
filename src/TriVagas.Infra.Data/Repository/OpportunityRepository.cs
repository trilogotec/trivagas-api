using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Infra.Data.Context;

namespace TriVagas.Infra.Data.Repository
{
    public class OpportunityRepository : BaseRepository<Opportunity>, IOpportunityRepository
    {
        public OpportunityRepository(DataContext context) : base(context)
        {
        }
    }
}