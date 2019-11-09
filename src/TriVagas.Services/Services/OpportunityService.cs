using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Services.Interfaces;

namespace TriVagas.Services.Services
{
    public class OpportunityService : IOpportunityService
    {

        private readonly IOpportunityRepository _opportunityRepository;
        public OpportunityService(IOpportunityRepository opportunityRepository)
        {
            _opportunityRepository = opportunityRepository;
        }

        public async Task<List<Opportunity>> GetAll()
        {
            return await _opportunityRepository.GetAll();
        }

        public async Task<Opportunity> GetById(int id)
        {
            return await _opportunityRepository.GetById(id);
        }

        public async Task<Opportunity> Register(Opportunity obj)
        {
            return await _opportunityRepository.Add(obj);
        }
        public async Task<Opportunity> Update(Opportunity obj)
        {
            return await _opportunityRepository.Update(obj);
        }

        public async Task<bool> Remove(int id)
        {
            return await _opportunityRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}