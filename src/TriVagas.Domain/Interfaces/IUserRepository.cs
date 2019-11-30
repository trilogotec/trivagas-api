using TriVagas.Domain.Models;
using System.Threading.Tasks;
using TriVagas.Domain.Models;

namespace TriVagas.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByCredentials(string email, string password);
        Task<User> GetByEmail(string email);
    }
}
