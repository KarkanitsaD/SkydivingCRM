using System;

namespace SkydivingCRM.SkydivingClubService.Api.Models.ResponseModels.Equipment
{
    public class EquipmentResponseModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsDecommissioned { get; set; }

        public Guid? AssignedSportsmanId { get; set; }

        public Guid StockId { get; set; }
    }
}