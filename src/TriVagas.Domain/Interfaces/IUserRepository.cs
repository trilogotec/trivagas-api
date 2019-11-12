using TriVagas.Domain.Models;
using System.Threading.Tasks;
using TriVagas.Domain.Models;

namespace TriVagas.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Login(string email, string password);
        Task<User> GetByEmail(string email);
    }
}
