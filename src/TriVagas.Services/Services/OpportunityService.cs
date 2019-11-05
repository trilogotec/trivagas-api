using System;
using System.Collections.Generic;
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

        public IEnumerable<Opportunity> GetAll()
        {
            return _opportunityRepository.GetAll();
        }

        public Opportunity GetById(int id)
        {
            return _opportunityRepository.GetById(id);
        }

        public void Register(Opportunity obj)
        {
            _opportunityRepository.Add(obj);
        }
        public void Update(Opportunity obj)
        {
            _opportunityRepository.Update(obj);
        }

        public void Remove(int id)
        {
            _opportunityRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}