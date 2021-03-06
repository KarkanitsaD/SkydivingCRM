using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Data.EntitiesConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(u => u.Login).IsRequired();

            builder.Property(u => u.DateOfRegistration).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}