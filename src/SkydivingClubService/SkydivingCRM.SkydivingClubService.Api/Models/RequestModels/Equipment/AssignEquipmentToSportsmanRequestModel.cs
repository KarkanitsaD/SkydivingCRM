using System;

namespace SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.Equipment
{
    public class AssignEquipmentToSportsmanRequestModel
    {
        public Guid SportsmanId { get; set; }

        public Guid EquipmentId { get; set; }
    }
}