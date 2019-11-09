using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Infra.Data.Context;

namespace TriVagas.Infra.Data.Repository
{
    public class PageRepository : BaseRepository<Page>, IPageRepository
    {
        public PageRepository(DataContext context) : base(context)
        {
        }
    }
}
