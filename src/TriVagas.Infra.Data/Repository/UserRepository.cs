using TriVagas.Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TriVagas.Domain.Models;
using TriVagas.Infra.Data.Context;

namespace TriVagas.Infra.Data.Repository
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(DataContext context) : base(context)
    {
    }
    public async Task<User> Login(string email, string password)
    {       
      return await DbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }

    public async Task<User> GetByEmail(string email)
    {
      return await DbSet.FirstOrDefaultAsync(u => u.Email == email);
    }
 
    public async Task<User> GetUserByCredentials(string email, string password)
    {
      return await DbSet.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
  }
}
