using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriVagas.Domain.Models;

namespace TriVagas.Infra.Data.Mapping
{
    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profiles");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                   .WithOne(u => u.Profile)
                   .HasForeignKey<Profile>(p => p.UserId);

            builder.HasOne(p => p.CreatedBy)
                   .WithOne()
                   .HasForeignKey<Profile>(p => p.CreatedById)
                   .IsRequired();
            
            builder.HasOne(p => p.LastUpdateBy)
                   .WithOne()
                   .HasForeignKey<Profile>(p => p.LastUpdateById)
                   .IsRequired();
        }
    }
}