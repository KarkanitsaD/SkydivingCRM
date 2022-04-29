using System;

namespace SkydivingCRM.SkydivingClubService.Data.Entities
{
    public class EquipmentEntity : Entity
    {
        public string Title { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsDecommissioned { get; set; }

        public Guid? AssignedSportsmanId { get; set; }

        public Guid StockId { get; set; }

        public StockEntity Stock { get; set; }
    }
}