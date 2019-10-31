using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class CompanyUserMap : IEntityTypeConfiguration<CompanyUser>
    {
        public void Configure(EntityTypeBuilder<CompanyUser> builder)
        {
            builder.ToTable("CompanyUsers");

            builder.HasKey(t => new {t.CompanyId, t.EmployeeId});

            builder.HasOne(cu => cu.Company)
                   .WithMany(c => c.CompanyEmployees)
                   .HasForeignKey(cu => cu.CompanyId);

            
            builder.HasOne(cu => cu.Employee)
                   .WithMany(u => u.CompaniesEmployees)
                   .HasForeignKey(cu => cu.EmployeeId);
        }
    }
}