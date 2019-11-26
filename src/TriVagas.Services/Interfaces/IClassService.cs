using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriVagas.Domain.Models;
using TriVagas.Services.Requests;
using TriVagas.Services.Responses;

namespace TriVagas.Services.Interfaces
{
    public interface IClassService : IDisposable
    {
        Task<List<Class>> GetAll();
        Task<ClassResponse> GetById(int id);
        Task<ClassResponse> Register(CreateClassRequest company, User user);
        Task<ClassResponse> Update(CreateClassRequest company, User user);
        Task<bool> Remove(int id);
    }
}
