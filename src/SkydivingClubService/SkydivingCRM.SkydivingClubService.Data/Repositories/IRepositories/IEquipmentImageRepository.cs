using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories
{
    public interface IEquipmentImageRepository : IRepository<EquipmentImageEntity>
    {
        Task<List<Guid>> GetImagesIdsByEquipmentIdAsync(Guid equipmentId);
    }
}