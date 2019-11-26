using TriVagas.Domain.Models;
using TriVagas.Domain.Interfaces;
using TriVagas.Infra.Data.Context;

namespace TriVagas.Infra.Data.Repository
{
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        public SessionRepository(DataContext context) : base(context)
        {
        }
    }
}