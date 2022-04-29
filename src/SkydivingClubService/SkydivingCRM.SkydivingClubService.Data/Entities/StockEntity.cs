using System;
using System.Collections.Generic;

namespace SkydivingCRM.SkydivingClubService.Data.Entities
{
    public class StockEntity : Entity
    {
        public Guid SkydivingClubId { get; set; }

        public SkydivingClubEntity SkydivingClub { get; set; }

        public string Title { get; set; }

        public List<EquipmentEntity> Equipments { get; set; }
    }
}