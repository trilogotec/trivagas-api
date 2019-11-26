using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriVagas.Domain.Models;
using TriVagas.Services.Requests;
using TriVagas.Services.Responses;

namespace TriVagas.Services.Interfaces
{
    public interface IOpportunityService : IDisposable
    {
        Task<List<Opportunity>> GetAll();
        Task<Opportunity> GetById(int id);
        Task<OpportunityResponse> Register(CreateOpportunityRequest opportunity, User user);
        Task<Opportunity> Update(Opportunity opportunity, User user);
        Task<bool> Remove(int id);
    }
}