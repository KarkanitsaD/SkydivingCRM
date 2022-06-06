using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Data.EntitiesConfigurations
{
    public class UserImageConfiguration : IEntityTypeConfiguration<UserImageEntity>
    {
        public void Configure(EntityTypeBuilder<UserImageEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.User)
                .WithOne(u => u.Image)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}