using System;
using System.Collections.Generic;
using SkydivingCRM.SkydivingClubService.Api.Models.ResponseModels.Equipment;

namespace SkydivingCRM.SkydivingClubService.Api.Models.ResponseModels.Stock
{
    public class StockResponseModel
    {
        public Guid Id { get; set; }

        public Guid SkydivingClubId { get; set; }

        public string Title { get; set; }

        public List<EquipmentResponseModel> Equipments { get; set; }
    }
}