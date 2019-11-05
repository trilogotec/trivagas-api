using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class PageUserMap : IEntityTypeConfiguration<PageUser>
    {
        public void Configure(EntityTypeBuilder<PageUser> builder)
        {
            builder.ToTable("PageOwners");

            builder.HasKey(po => new {po.PageId, po.OwnerId});

            builder.HasOne(po => po.Page)
                   .WithMany(p => p.PageOwners)
                   .HasForeignKey(po => po.PageId);

            
            builder.HasOne(po => po.Owner)
                   .WithMany(u => u.PageOwners)
                   .HasForeignKey(po => po.OwnerId);
        }
    }
}