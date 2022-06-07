using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.SkydivingClubService.Data.Entities;
using SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories;

namespace SkydivingCRM.SkydivingClubService.Data.Repositories
{
    public class EquipmentImageRepository : Repository<EquipmentImageEntity>, IEquipmentImageRepository
    {
        public EquipmentImageRepository(SkydivingClubContext context) : base(context)
        {
        }


        public async Task<List<Guid>> GetImagesIdsByEquipmentIdAsync(Guid equipmentId)
        {
            var ids = await DbSet.Where(i => i.EquipmentId == equipmentId).Select(i => i.Id).ToListAsync();
            return ids;
        }
    }
}