using System;

namespace SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.EquipmentImage
{
    public class AddEquipmentImageRequestModel
    {
        public Guid EquipmentId { get; set; }

        public string Base64 { get; set; }
    }
}