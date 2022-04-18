using Microsoft.EntityFrameworkCore;
using SkydivingCRM.SkydivingClubService.Data.Entities;
using SkydivingCRM.SkydivingClubService.Data.EntitiesConfigurations;

namespace SkydivingCRM.SkydivingClubService.Data
{
    public class SkydivingClubContext : DbContext
    {
        public SkydivingClubContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration())
                .ApplyConfiguration(new CityEntityConfiguration())
                .ApplyConfiguration(new SkydivingClubEntityConfiguration())
                .ApplyConfiguration(new SkydivingGroupEntityConfiguration());
        }

        public DbSet<CountryEntity> Countries { get; set; }

        public DbSet<CityEntity> Cities { get; set; }

        public DbSet<SkydivingClubEntity> SkydivingClubs { get; set; }

        public DbSet<SkydivingGroupEntity> SkydivingGroups { get; set; }
    }
}