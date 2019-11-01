using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.LastUpdateById).IsRequired(false);
            builder.Property(u => u.CreatedById).IsRequired(false);

            builder.Property(u => u.ProfileId).IsRequired(false);

            builder.HasOne(u => u.CreatedBy)
                   .WithMany()
                   .HasForeignKey(u => u.CreatedById)
                   .IsRequired(false);

            builder.HasOne(u => u.LastUpdateBy)
                   .WithMany()
                   .HasForeignKey(u => u.LastUpdateById)
                   .IsRequired(false);
        }
    }
}