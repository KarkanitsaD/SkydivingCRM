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
            modelBuilder.ApplyConfiguration(new SkydivingClubEntityConfiguration())
                .ApplyConfiguration(new SkydivingGroupEntityConfiguration())
                .ApplyConfiguration(new StockEntityConfiguration())
                .ApplyConfiguration(new EquipmentEntityConfiguration());
        }

        public DbSet<SkydivingClubEntity> SkydivingClubs { get; set; }

        public DbSet<SkydivingGroupEntity> SkydivingGroups { get; set; }

        public DbSet<StockEntity> Stocks { get; set; }

        public DbSet<EquipmentEntity> Equipments { get; set; }
    }
}