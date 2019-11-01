using System;
using System.Collections.Generic;
using TriVagas.Domain.Models;

namespace TriVagas.Services.Interfaces
{
    public interface IOpportunityService : IDisposable
    {
        IEnumerable<Opportunity> GetAll();
        Opportunity GetById(int id);
        void Register(Opportunity opportunity);
        void Update(Opportunity opportunity);
        void Remove(int id);
    }
}