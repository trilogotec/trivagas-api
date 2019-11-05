using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States");

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