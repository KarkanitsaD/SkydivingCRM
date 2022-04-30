using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkydivingCRM.SkydivingClubService.Business.Models.Equipment;
using SkydivingCRM.SkydivingClubService.Business.Models.Stock;

namespace SkydivingCRM.SkydivingClubService.Business.Services.IServices
{
    public interface IStockService
    {
        Task<StockModel> CreateStock(StockModel stock);

        Task ClearStock(Guid stockId);

        Task<StockModel> UpdateStock(StockModel stock);

        Task<List<EquipmentModel>> GetEquipmentsByStockId(Guid stockId);
    }
}