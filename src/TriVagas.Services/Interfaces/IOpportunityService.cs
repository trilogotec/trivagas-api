using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriVagas.Domain.Models;

namespace TriVagas.Services.Interfaces
{
    public interface IOpportunityService : IDisposable
    {
        Task<List<Opportunity>> GetAll();
        Task<Opportunity> GetById(int id);
        Task<Opportunity> Register(Opportunity opportunity);
        Task<Opportunity> Update(Opportunity opportunity);
        Task<bool> Remove(int id);
    }
}