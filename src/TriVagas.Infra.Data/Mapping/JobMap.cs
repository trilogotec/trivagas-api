using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class JobMap : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");

            builder.HasKey(j => j.Id);

            builder.HasOne(c => c.CreatedBy)
                   .WithMany()
                   .HasForeignKey(c => c.CreatedById)
                   .IsRequired();
            
            builder.HasOne(c => c.LastUpdateBy)
                   .WithMany()
                   .HasForeignKey(c => c.LastUpdateById)
                   .IsRequired();

            builder.HasOne(j => j.Profile)
                   .WithMany(p => p.Experience)
                   .HasForeignKey(j => j.ProfileId);

            builder.HasOne(j => j.Company)
                   .WithMany(c => c.Jobs)
                   .HasForeignKey(j => j.CompanyId);

            builder.HasOne(j => j.Position)
                   .WithMany(p => p.Jobs)
                   .HasForeignKey(j => j.PositionId);
        }
    }
}