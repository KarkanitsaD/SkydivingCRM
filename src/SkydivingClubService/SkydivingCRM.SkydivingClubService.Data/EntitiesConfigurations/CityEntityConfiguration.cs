using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Data.EntitiesConfigurations
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title).IsRequired();

            builder.HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);
        }
    }
}