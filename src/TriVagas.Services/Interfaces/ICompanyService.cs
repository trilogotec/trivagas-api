using System;
using System.Threading.Tasks;
using TriVagas.Domain.Models;
using TriVagas.Services.Requests;

namespace TriVagas.Services.Interfaces
{
    public interface ICompanyService : IDisposable
    {
        Task<Company> CreateCompany(CreatePageRequest request, User user);
    }
}
