using System;
using System.Collections.Generic;
using SkydivingCRM.SkydivingClubService.Business.Models.Stock;

namespace SkydivingCRM.SkydivingClubService.Business.Models.Equipment
{
    public class EquipmentModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsDecommissioned { get; set; }

        public Guid? AssignedSportsmanId { get; set; }

        public Guid StockId { get; set; }

        public StockModel Stock { get; set; }

        public List<string> ImagesIds { get; set; }
    }
}