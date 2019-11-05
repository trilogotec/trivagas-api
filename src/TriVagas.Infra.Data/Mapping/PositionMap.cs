using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class PositionMap : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.CreatedBy)
                   .WithMany()
                   .HasForeignKey(p => p.CreatedById)
                   .IsRequired();
            
            builder.HasOne(p => p.LastUpdateBy)
                   .WithMany()
                   .HasForeignKey(p => p.LastUpdateById)
                   .IsRequired();
        }
    }
}