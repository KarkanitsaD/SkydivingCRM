using System.Text.RegularExpressions;
using SkydivingCRM.UserService.Business.Models.Media;
using SkydivingCRM.UserService.Business.Services.IServices;

namespace SkydivingCRM.UserService.Business.Services
{
    public class MediaService : IMediaService
    {
        public const string Base64ValidationRegex = @"\w+:\w+/\w+\+?\w*;\w+,\S+$";

        public MediaByteArrayModel GetByteArrayModelFromBase64(string base64)
        {
            var imageParts = base64.Split(',');

            var content = imageParts[1];

            var extension = imageParts[0].Split(':')[1].Split(';')[0];

            return new MediaByteArrayModel(content, extension);
        }

        public bool IsValidBase64(string base64)
        {
            var regex = new Regex(Base64ValidationRegex);
            return regex.IsMatch(base64);
        }
    }
}