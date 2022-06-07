using System;
using System.Collections.Generic;

namespace SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.Equipment
{
    public class AddEquipmentRequestModel
    {
        public Guid StockId { get; set; }

        public string Title { get; set; }

        public Guid? AssignedSportsmanId { get; set; }

        public List<string> Images { get; set; }
    }
}