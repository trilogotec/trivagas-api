using TriVagas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TriVagas.Infra.Data.Mapping
{
    public class OpportunityMap : IEntityTypeConfiguration<Opportunity>
    {
        public void Configure(EntityTypeBuilder<Opportunity> builder)
        {
            builder.ToTable("Opportunity");

            builder.HasKey(o => o.Id);           

            builder.HasOne(o => o.Company)
                   .WithMany(c => c.Opportunities)
                   .HasForeignKey(o => o.CompanyId);
            
            builder.HasOne(o => o.Class)
                   .WithMany(c => c.Opportunities)
                   .HasForeignKey(o => o.ClassId);
            
            builder.HasOne(o => o.Job)
                   .WithOne(j => j.Opportunity)
                   .HasForeignKey<Job>(j => j.OpportunityId);
        }
    }
}