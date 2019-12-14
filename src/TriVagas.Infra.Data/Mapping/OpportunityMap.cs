using TriVagas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TriVagas.Infra.Data.Mapping
{
    public class OpportunityMap : IEntityTypeConfiguration<Opportunity>
    {
        public void Configure(EntityTypeBuilder<Opportunity> builder)
        {
            builder.ToTable("Opportunities");

            builder.HasKey(o => o.Id);

            //builder.Property(o => o.SalaryMax).HasColumnType("decimal(10,2)");
            //builder.Property(o => o.SalaryMin).HasColumnType("decimal(10,2)");

            builder.HasOne(o => o.Company)
                   .WithMany(c => c.Opportunities)
                   .HasForeignKey(o => o.CompanyId);
            
            builder.HasOne(o => o.Class)
                   .WithMany(c => c.Opportunities)
                   .HasForeignKey(o => o.ClassId);
            
            builder.HasOne(o => o.Job)
                   .WithOne(j => j.Opportunity)
                   .HasForeignKey<Job>(j => j.OpportunityId);

            builder.HasOne(o => o.CreatedBy)
                   .WithMany()
                   .HasForeignKey(o => o.CreatedById)
                   .IsRequired();
            
            builder.HasOne(o => o.LastUpdateBy)
                   .WithMany()
                   .HasForeignKey(o => o.LastUpdateById)
                   .IsRequired();
        }
    }
}