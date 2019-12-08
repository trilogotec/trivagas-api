using AutoMapper;
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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public OpportunityService(
            IOpportunityRepository opportunityRepository,
            ICompanyRepository companyRepository,
            IClassRepository classRepository,
            IUserService userService,
            INotify notify,
            IMapper mapper) : base(notify)
        {
            _opportunityRepository = opportunityRepository;
            _companyRepository = companyRepository;
            _classRepository = classRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<List<OpportunityResponse>> GetAll()
        {
            return _mapper.Map<List<OpportunityResponse>>(await _opportunityRepository.GetAll());
        }

        public async Task<OpportunityResponse> GetById(int id)
        {
            var opportunity = await _opportunityRepository.GetById(id);
            return _mapper.Map<OpportunityResponse>(opportunity);
        }

        public async Task<OpportunityResponse> Register(CreateOpportunityRequest obj)
        {
            var user = await _userService.GetById(obj.UserId);
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
                var createdOpportunity = await _opportunityRepository.Add(_mapper.Map<Opportunity>(obj));

                return _mapper.Map<OpportunityResponse>(createdOpportunity);
            }
            else
            {
                return null;
            }
        }

        public async Task<OpportunityResponse> Update(UpdateOpportunityRequest obj)
        {
            var opportunity = await _opportunityRepository.GetById(obj.id);
            if (opportunity == null)
                Notify("Opportunity not found");

            var user = await _userService.GetById(obj.UserId);
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
                var updateOpportunity = _mapper.Map(obj, opportunity);
                return _mapper.Map<OpportunityResponse>(await _opportunityRepository.Update(updateOpportunity));
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Remove(int id)
        {
            return await _opportunityRepository.Remove(id);
        }
    }
}