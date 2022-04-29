using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories
{
    public interface IEquipmentRepository : IRepository<EquipmentEntity>
    {
        Task RemoveRangeAsync(IEnumerable<EquipmentEntity> equipments);

        Task<List<EquipmentEntity>> GetAllByStockIdAsync(Guid stockId);
    }
}