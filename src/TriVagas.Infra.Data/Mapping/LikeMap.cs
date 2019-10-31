using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class LikeMap : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes");

            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.CreatedBy)
                   .WithMany()
                   .HasForeignKey(l => l.CreatedById)
                   .IsRequired();
            
            builder.HasOne(l => l.LastUpdateBy)
                   .WithMany()
                   .HasForeignKey(l => l.LastUpdateById)
                   .IsRequired();
        }
    }
}