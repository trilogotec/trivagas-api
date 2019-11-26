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

    public class CompanyService : BaseService , ICompanyService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyUserRepository _companyUserRepository;

        public CompanyService( 
            ICityRepository cityRepository,
            ICompanyRepository companyRepository,
            ICompanyUserRepository companyUserRepository,
            INotify notify) : base(notify)
        {
            _cityRepository = cityRepository;
            _companyRepository = companyRepository;
            _companyUserRepository = companyUserRepository;
        }

        public async Task<Company> CreateCompany(CreatePageRequest request,User user) 
        {
            if (user == null) 
                Notify("User not found");

            var city = await _cityRepository.GetById(request.CityId);

            if (city == null)
                Notify("City not found");


            if (!HasNotification())
            {
                var newCompany = new Company(request.Name, city, request.LinkedIn, user);
                await _companyRepository.Add(newCompany);

                return await _companyRepository.GetById(newCompany.Id);
            }
            else
                return null;
        }

        public async Task<List<Company>> GetAll()
        {
            return await _companyRepository.GetAll();
        }

        public async Task<CompanyResponse> GetById(int id)
        {
            var company = await _companyRepository.GetById(id);
            return new CompanyResponse()
            {
                Id = company.Id,
                Name = company.Name,
                LinkedIn = company.LinkedIn,
                City = company.City
            };
        }

        public async Task<CompanyResponse> Register(CreateCompanyRequest company, User user)
        {
            var city = await _cityRepository.GetById(company.CityId);

            if (city == null)
                Notify("City not found");

            if (user == null) 
                Notify("User not found");

            if (!HasNotification())
            {
                var newCompany = new Company(company.Name, city, company.LinkedIn, user);
                await _companyRepository.Add(newCompany);

                var newCompanyUser = new CompanyUser(newCompany, user);
                await _companyUserRepository.Add(newCompanyUser);

                var companyResponse = new CompanyResponse() { 
                                        Id = newCompany.Id,
                                        Name = newCompany.Name,
                                        LinkedIn = newCompany.LinkedIn,
                                        City = newCompany.City};
                return companyResponse;
            }
            else
                return null;
        }

        public async Task<bool> Remove(int id)
        {
            return await _companyRepository.Remove(id);
        }

        public Task<CompanyResponse> Update(CreateCompanyRequest company, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
