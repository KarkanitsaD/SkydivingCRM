using System;

namespace SkydivingCRM.UserService.Data.Entities
{
    public class SkydivingGroupInstructorEntity
    {
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }

        public Guid GroupId { get; set; }

        public DateTime FormationDate { get; set; }
    }
}