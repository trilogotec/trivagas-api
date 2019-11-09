using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Notify;
using TriVagas.Services.Requests;

namespace TriVagas.Services.Services
{

    public class CompanyService : BaseService , ICompanyService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICompanyRepository _companyRepository;
        public CompanyService( 
            ICityRepository cityRepository,
            ICompanyRepository companyRepository,
            INotify notify) : base(notify)
        {
            _cityRepository = cityRepository;
            _companyRepository = companyRepository;
        }

        public Company CreateCompany(CreatePageRequest request,User user) 
        {
            if (user == null) 
                Notify("User not found");

            var city = _cityRepository.GetById(request.CityId);

            if (city == null)
                Notify("City not found");


            if (!HasNotification())
            {
                var newCompany = new Company(request.Name, city, request.LinkedIn, user);
                _companyRepository.Add(newCompany);

                return _companyRepository.GetById(newCompany.Id);
            }
            else
                return null;
        }
    }
}
