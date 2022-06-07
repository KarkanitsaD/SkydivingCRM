using System;
using System.Threading.Tasks;

namespace SkydivingCRM.SkydivingClubService.Business.Services.IServices
{
    public interface IEquipmentImageService
    {
        Task AddImage(Guid equipmentId, string base64);

        Task RemoveImage(Guid imageId);
    }
}