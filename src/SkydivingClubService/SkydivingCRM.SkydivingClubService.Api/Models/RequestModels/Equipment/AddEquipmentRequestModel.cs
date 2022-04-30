using System;

namespace SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.Equipment
{
    public class AddEquipmentRequestModel
    {
        public Guid StockId { get; set; }

        public string Title { get; set; }

        public Guid? AssignedSportsmanId { get; set; }
    }
}