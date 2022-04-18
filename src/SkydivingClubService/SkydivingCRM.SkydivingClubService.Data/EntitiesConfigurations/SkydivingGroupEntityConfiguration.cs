using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Data.EntitiesConfigurations
{
    public class SkydivingGroupEntityConfiguration : IEntityTypeConfiguration<SkydivingGroupEntity>
    {
        public void Configure(EntityTypeBuilder<SkydivingGroupEntity> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Title).IsRequired();

            builder.Property(g => g.RegistrationDate).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(g => g.FoundationDate).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(g => g.SkydivingClub)
                .WithMany(c => c.SkydivingGroups)
                .HasForeignKey(g => g.SkydivingClubId);
        }
    }
}