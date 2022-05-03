using System;
using System.Threading.Tasks;
using SkydivingCRM.SkydivingClubService.Business.Models.Equipment;

namespace SkydivingCRM.SkydivingClubService.Business.Services.IServices
{
    public interface IEquipmentService
    {
        Task<EquipmentModel> GetEquipment(Guid equipmentId);

        Task<EquipmentModel> UpdateEquipment(EquipmentModel equipment);

        Task<EquipmentModel> AddEquipment(EquipmentModel equipment);

        Task<EquipmentModel> DecommissionEquipment(Guid equipmentId);

        Task<EquipmentModel> AssignEquipmentToSportsman(Guid equipmentId, Guid sportsmanId);

        Task<EquipmentModel> MoveToAnotherStock(Guid equipmentId, Guid stockId);

        Task RemoveEquipment(Guid equipmentId);
    }
}