using TriVagas.Domain.Models;

namespace TriVagas.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
    }
}
