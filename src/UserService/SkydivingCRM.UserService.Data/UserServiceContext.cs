using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.UserService.Data.Entities;
using SkydivingCRM.UserService.Data.EntitiesConfigurations;

namespace SkydivingCRM.UserService.Data
{
    public class UserServiceContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        public UserServiceContext(DbContextOptions<UserServiceContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserEntityConfiguration())
                .ApplyConfiguration(new SkydivingGroupInstructorEntityConfiguration())
                .ApplyConfiguration(new SkydivingGroupSportsmanEntityConfiguration());
        }

        public DbSet<SkydivingGroupInstructorEntity> SkydivingGroupInstructors { get; set; }

        public DbSet<SkydivingGroupSportsmanEntity> SkydivingGroupSportsmen { get; set; }

        public DbSet<UserImageEntity> UserImages { get; set; }
    }
}