using System;
using System.Threading.Tasks;
using TriVagas.Domain.Models;

namespace TriVagas.Services.Interfaces
{
    public interface IPageServer : IDisposable
    {
        Task<Page> CreatePage(Company company, User user);
    }
}
