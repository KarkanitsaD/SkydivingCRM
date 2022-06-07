using System;

namespace SkydivingCRM.SkydivingClubService.Data.Entities
{
    public class EquipmentImageEntity : MediaEntity
    {
        public EquipmentImageEntity()
        {

        }

        public EquipmentImageEntity(byte[] content, string extension, Guid equipmentId)
        {
            Content = content;
            Extension = extension;
            EquipmentId = equipmentId;
        }

        public Guid EquipmentId { get; set; }

        public EquipmentEntity Equipment { get; set; }
    }
}