using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

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