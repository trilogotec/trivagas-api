using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Infra.Data.Context;

namespace TriVagas.Infra.Data.Repository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DataContext context) : base(context)
        {
        }
    }
}
