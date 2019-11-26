using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Infra.Data.Context;

namespace TriVagas.Infra.Data.Repository
{
    public class CompanyUserRepository : BaseRepository<CompanyUser>, ICompanyUserRepository
    {
        public CompanyUserRepository(DataContext context) : base(context)
        {
        }
    }
}
