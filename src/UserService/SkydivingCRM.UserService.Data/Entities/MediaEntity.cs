using System;

namespace SkydivingCRM.UserService.Data.Entities
{
    public class MediaEntity
    {
        public Guid Id { get; set; }

        public byte[] Content { get; set; }

        public string Extension { get; set; }
    }
}