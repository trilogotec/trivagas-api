using TriVagas.Domain.Models;
using System.Threading.Tasks;

namespace TriVagas.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByCredentials(string email, string password);
        Task<User> GetByEmail(string email);
        Task<User> Login(string email, string password);
  }
}
