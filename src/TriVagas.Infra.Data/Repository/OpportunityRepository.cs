using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async override Task<List<Opportunity>> GetAll()
        {
            return await DbSet.AsNoTracking()
                .Include(o => o.Company)
                .Include(o => o.Class)
                .Include(o => o.CreatedBy)
                .Include(o => o.LastUpdateBy)
                .ToListAsync();
        }

        public async override Task<Opportunity> GetById(int id)
        {
            return await DbSet
                .Include(o => o.Company)
                .Include(o => o.Class)
                .Include(o => o.CreatedBy)
                .Include(o => o.LastUpdateBy)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
