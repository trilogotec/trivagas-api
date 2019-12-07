using System;
using TriVagas.Domain.Models;
using TriVagas.Services.Requests;
using MapperProfile = AutoMapper.Profile;

namespace TriVagas.Services.AutoMapper
{
    public class RequestToDomainProfile : MapperProfile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CreateOpportunityRequest, Opportunity>()
                .ConstructUsing(o => new Opportunity(o.Title, o.CompanyId, o.ClassId, o.Description, o.JobType, o.SalaryMin, o.SalaryMax, o.UserId))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UpdateOpportunityRequest, Opportunity>()
                .ForMember(o => o.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(o => o.CompanyId, opt => opt.MapFrom(x => x.CompanyId))
                .ForMember(o => o.ClassId, opt => opt.MapFrom(x => x.ClassId))
                .ForMember(o => o.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(o => o.JobType, opt => opt.MapFrom(x => x.JobType))
                .ForMember(o => o.SalaryMin, opt => opt.MapFrom(x => x.SalaryMin))
                .ForMember(o => o.SalaryMax, opt => opt.MapFrom(x => x.SalaryMax))
                .ForMember(o => o.JobType, opt => opt.MapFrom(x => x.JobType))
                .ForMember(o => o.LastUpdateById, opt => opt.MapFrom(x => x.UserId))
                .ForMember(o => o.LastUpdate, opt => opt.MapFrom(x => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
