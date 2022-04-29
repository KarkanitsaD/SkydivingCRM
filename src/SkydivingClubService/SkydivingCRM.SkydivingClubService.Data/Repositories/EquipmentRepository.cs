using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.SkydivingClubService.Data.Entities;
using SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories;

namespace SkydivingCRM.SkydivingClubService.Data.Repositories
{
    public class EquipmentRepository : Repository<EquipmentEntity>, IEquipmentRepository
    {
        public EquipmentRepository(SkydivingClubContext context)
            : base(context)
        {
        }

        public async Task RemoveRangeAsync(IEnumerable<EquipmentEntity> equipments)
        {
            DbSet.RemoveRange(equipments);
            await Context.SaveChangesAsync();
        }

        public async Task<List<EquipmentEntity>> GetAllByStockIdAsync(Guid stockId)
        {
            return await DbSet.Where(e => e.StockId == stockId).ToListAsync();
        }
    }
}