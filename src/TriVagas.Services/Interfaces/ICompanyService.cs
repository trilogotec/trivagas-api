using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriVagas.Domain.Models;
using TriVagas.Services.Requests;
using TriVagas.Services.Responses;

namespace TriVagas.Services.Interfaces
{
    public interface ICompanyService : IDisposable
    {
        Task<List<Company>> GetAll();
        Task<CompanyResponse> GetById(int id);
        Task<CompanyResponse> Register(CreateCompanyRequest company, User user);
        Task<CompanyResponse> Update(CreateCompanyRequest company, User user);
        Task<bool> Remove(int id);

        Task<Company> CreateCompany(CreatePageRequest request, User user);
    }
}
