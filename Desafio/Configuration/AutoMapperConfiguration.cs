using AutoMapper;
using Desafio.Models;
using Desafio.ViewModel;

namespace Desafio.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<RegisterUserViewModel, User>();
            CreateMap<User, UserViewModel>();
            CreateMap<CompanyViewModel, Company>().ReverseMap();
            CreateMap<PageViewModel, Page>().ReverseMap();
        }
    }
}
