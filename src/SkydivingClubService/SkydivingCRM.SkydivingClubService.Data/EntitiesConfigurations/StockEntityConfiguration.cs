using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Data.EntitiesConfigurations
{
    public class StockEntityConfiguration : IEntityTypeConfiguration<StockEntity>
    {
        public void Configure(EntityTypeBuilder<StockEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.SkydivingClub)
                .WithMany(c => c.Stocks)
                .HasForeignKey(s => s.SkydivingClubId);

            builder.Property(s => s.Title).IsRequired();
        }
    }
}