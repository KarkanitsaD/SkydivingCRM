using System;

namespace SkydivingCRM.SkydivingClubService.Data.Entities
{
    public class EquipmentImageEntity : MediaEntity
    {
        public Guid EquipmentId { get; set; }

        public EquipmentEntity Equipment { get; set; }
    }
}