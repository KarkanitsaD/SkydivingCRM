using System;
using System.Collections.Generic;
using SkydivingCRM.SkydivingClubService.Business.Models.Equipment;
using SkydivingCRM.SkydivingClubService.Business.Models.SkydivingClub;

namespace SkydivingCRM.SkydivingClubService.Business.Models.Stock
{
    public class StockModel
    {
        public Guid Id { get; set; }

        public Guid SkydivingClubId { get; set; }

        public SkydivingClubModel SkydivingClub { get; set; }

        public string Title { get; set; }

        public List<EquipmentModel> Equipments { get; set; }
    }
}