using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Data.EntitiesConfigurations
{
    public class CountryEntityConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Title).IsRequired();
        }
    }
}