using TriVagas.Domain.Models;
using TriVagas.Services.Responses;
using MapperProfile = AutoMapper.Profile;

namespace TriVagas.Services.AutoMapper
{
    public class DomainToResponseProfile : MapperProfile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Opportunity, OpportunityResponse>()
                .ConstructUsing(o => new OpportunityResponse()
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    JobType = o.JobType,
                    CreatedBy = o.CreatedBy == null ? null : new UserResponse() { Id = o.CreatedBy.Id, Email = o.CreatedBy.Email },
                    CreationDate = o.CreationDate,
                    LastUpdateBy = o.LastUpdate == null ? null : new UserResponse() { Id = o.LastUpdateBy.Id, Email = o.LastUpdateBy.Email },
                    LastUpdate = o.LastUpdate,
                    SalaryMin = o.SalaryMin,
                    SalaryMax = o.SalaryMax,
                    Company = o.Company == null ? null : new CompanyResponse()
                    {
                        Id = o.Company.Id,
                        City = o.Company.City,
                        LinkedIn = o.Company.LinkedIn,
                        Name = o.Company.Name
                    },
                    Class = o.Class == null ? null : new ClassResponse()
                    {
                        Id = o.Class.Id,
                        Name = o.Class.Name
                    }
                }).ForAllOtherMembers(x => x.Ignore());
        }
    }
}
