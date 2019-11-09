using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Infra.Data.Context;

namespace TriVagas.Infra.Data.Repository
{
    public class PageOwnerRepository : BaseRepository<PageUser>, IPageOwnerRepository
    {
        public PageOwnerRepository(DataContext context) : base(context)
        {
        }
    }
}
