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
        Task<List<OpportunityResponse>> GetAll();
        Task<OpportunityResponse> GetById(int id);
        Task<OpportunityResponse> Register(CreateOpportunityRequest opportunity);
        Task<OpportunityResponse> Update(UpdateOpportunityRequest opportunity);
        Task<bool> Remove(int id);
    }
}