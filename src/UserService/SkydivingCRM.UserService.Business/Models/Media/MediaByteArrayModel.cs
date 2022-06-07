using System;

namespace SkydivingCRM.UserService.Business.Models.Media
{
    public class MediaByteArrayModel
    {
        public MediaByteArrayModel()
        {
        }

        public MediaByteArrayModel(string content, string extension)
        {
            Content = Convert.FromBase64String(content);
            Extension = extension;
        }

        public byte[] Content { get; set; }

        public string Extension { get; set; }
    }
}