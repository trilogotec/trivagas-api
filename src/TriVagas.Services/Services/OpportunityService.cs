using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Notify;
using TriVagas.Services.Requests;
using TriVagas.Services.Responses;

namespace TriVagas.Services.Services
{
    public class OpportunityService : BaseService, IOpportunityService
    {

        private readonly IOpportunityRepository _opportunityRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IClassRepository _classRepository;

        public OpportunityService(
            IOpportunityRepository opportunityRepository,
            ICompanyRepository companyRepository,
            IClassRepository classRepository,
            INotify notify) : base(notify)
        {
            _opportunityRepository = opportunityRepository;
            _companyRepository = companyRepository;
            _classRepository = classRepository;
        }

        public async Task<List<Opportunity>> GetAll()
        {
            return await _opportunityRepository.GetAll();
        }

        public async Task<Opportunity> GetById(int id)
        {
            return await _opportunityRepository.GetById(id);
        }

        public async Task<OpportunityResponse> Register(CreateOpportunityRequest obj, User user)
        {
            if (user == null)
                Notify("User not found");

            var company = await _companyRepository.GetById(obj.CompanyId);
            if (company == null)
                Notify("Company not found");

            var classObj = await _classRepository.GetById(obj.ClassId);
            if (classObj == null)
                Notify("Class not found");

            if (!HasNotification())
            {
                var newOpportunity = new Opportunity(obj.Title, company, classObj, obj.Description, obj.JobType, obj.SalaryMin, obj.SalaryMax, user); 
                var createdOpportunity = await _opportunityRepository.Add(newOpportunity);

                var response = new OpportunityResponse()
                {
                    Id = createdOpportunity.Id,
                    Title = createdOpportunity.Title,
                    Description = createdOpportunity.Description
                };

                return response;
            }
            else
                return null;
        }
        public async Task<Opportunity> Update(Opportunity obj, User user)
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