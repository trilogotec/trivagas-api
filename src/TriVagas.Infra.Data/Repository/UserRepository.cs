using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Infra.Data.Context;

namespace TriVagas.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
