using System;
using TriVagas.Domain.Models;
using TriVagas.Services.Requests;

namespace TriVagas.Services.Interfaces
{
    public interface ICompanyService : IDisposable
    {
        Company CreateCompany(CreatePageRequest request, User user);
    }
}
