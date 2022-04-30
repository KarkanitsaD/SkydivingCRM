using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Data.EntitiesConfigurations
{
    public class EquipmentEntityConfiguration : IEntityTypeConfiguration<EquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(e => e.Stock)
                .WithMany(s => s.Equipments)
                .HasForeignKey(e => e.StockId);

            builder.Property(e => e.Title).IsRequired();

            builder.Property(e => e.DateAdded).HasDefaultValue(DateTime.Now);

            builder.Property(e => e.IsDecommissioned).HasDefaultValue(false);
        }
    }
}