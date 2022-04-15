using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Data.EntitiesConfigurations
{
    public class SkydivingGroupSportsmanEntityConfiguration : IEntityTypeConfiguration<SkydivingGroupSportsmanEntity>
    {
        public void Configure(EntityTypeBuilder<SkydivingGroupSportsmanEntity> builder)
        {
            builder.HasKey(gi => new { gi.UserId, gi.GroupId });

            builder.HasOne(gi => gi.User).WithMany(u => u.SkydivingGroupsAsSportsman);

            builder.Property(gi => gi.FormationDate).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}