using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Data.EntitiesConfigurations
{
    public class SkydivingClubEntityConfiguration : IEntityTypeConfiguration<SkydivingClubEntity>
    {
        public void Configure(EntityTypeBuilder<SkydivingClubEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title).IsRequired();

            builder.Property(b => b.Address).IsRequired();

            builder.Property(b => b.Description);

            builder.Property(b => b.FoundationDate).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(b => b.RegistrationDate).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(b => b.City)
                .WithMany(c => c.SkydivingClubs)
                .HasForeignKey(b => b.CityId);
        }
    }
}