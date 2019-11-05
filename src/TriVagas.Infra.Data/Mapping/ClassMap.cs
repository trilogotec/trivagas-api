using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class ClassMap : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.CreatedBy)
                   .WithMany()
                   .HasForeignKey(c => c.CreatedById)
                   .IsRequired();
            
            builder.HasOne(c => c.LastUpdateBy)
                   .WithMany()
                   .HasForeignKey(c => c.LastUpdateById)
                   .IsRequired();
        }
    }
}