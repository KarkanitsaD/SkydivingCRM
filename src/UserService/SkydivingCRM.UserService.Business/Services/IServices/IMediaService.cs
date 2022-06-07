using SkydivingCRM.UserService.Business.Models.Media;

namespace SkydivingCRM.UserService.Business.Services.IServices
{
    public interface IMediaService
    {
        MediaByteArrayModel GetByteArrayModelFromBase64(string base64);

        bool IsValidBase64(string base64);
    }
}