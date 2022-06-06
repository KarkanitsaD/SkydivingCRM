using System;

namespace SkydivingCRM.UserService.Data.Entities
{
    public class UserImageEntity : MediaEntity
    {
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
    }
}