using System;

namespace SkydivingCRM.UserService.Data.Entities
{
    public class SkydivingGroupSportsmanEntity
    {
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }

        public Guid GroupId { get; set; }

        public DateTimeOffset FormationDate { get; set; }
    }
}