using System;

namespace SkydivingCRM.UserService.Data.Entities
{
    public class UserImageEntity : MediaEntity
    {
        public UserImageEntity()
        {

        }

        public UserImageEntity(byte[] content, string extension, Guid userId)
        {
            Content = content;
            Extension = extension;
            UserId = userId;
        }

        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
    }
}