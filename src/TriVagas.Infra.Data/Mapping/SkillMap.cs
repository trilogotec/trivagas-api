using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class SkillMap : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");

            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.CreatedBy)
                   .WithMany()
                   .HasForeignKey(s => s.CreatedById)
                   .IsRequired();
            
            builder.HasOne(s => s.LastUpdateBy)
                   .WithMany()
                   .HasForeignKey(s => s.LastUpdateById)
                   .IsRequired();
        }
    }
}