using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Data.EntitiesConfigurations
{
    public class SkydivingGroupInstructorEntityConfiguration : IEntityTypeConfiguration<SkydivingGroupInstructorEntity>
    {
        public void Configure(EntityTypeBuilder<SkydivingGroupInstructorEntity> builder)
        {
            builder.HasKey(gi => new { gi.UserId, gi.GroupId });

            builder.HasOne(gi => gi.User).WithMany(u => u.SkydivingGroupsAsInstructor);

            builder.Property(gi => gi.FormationDate).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}