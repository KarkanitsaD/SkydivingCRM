using SkydivingCRM.SkydivingClubService.Business.Models.Media;

namespace SkydivingCRM.SkydivingClubService.Business.Services.IServices
{
    public interface IMediaService
    {
        MediaByteArrayModel GetByteArrayModelFromBase64(string base64);

        bool IsValidBase64(string base64);
    }
}