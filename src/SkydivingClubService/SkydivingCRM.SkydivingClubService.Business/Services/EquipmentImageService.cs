using System;
using System.Threading.Tasks;
using SkydivingCRM.SkydivingClubService.Business.Services.IServices;
using SkydivingCRM.SkydivingClubService.Data.Entities;
using SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories;

namespace SkydivingCRM.SkydivingClubService.Business.Services
{
    public class EquipmentImageService : IEquipmentImageService
    {
        private readonly IEquipmentImageRepository _equipmentImageRepository;
        private readonly IMediaService _mediaService;

        public EquipmentImageService(IEquipmentImageRepository equipmentImageRepository, IMediaService mediaService)
        {
            _equipmentImageRepository = equipmentImageRepository;
            _mediaService = mediaService;
        }

        public async Task AddImage(Guid equipmentId, string base64)
        {
            var mediaModel = _mediaService.GetByteArrayModelFromBase64(base64);
            var equipmentImageEntity = new EquipmentImageEntity(mediaModel.Content, mediaModel.Extension, equipmentId);

            await _equipmentImageRepository.CreateAsync(equipmentImageEntity);
        }

        public async Task RemoveImage(Guid imageId)
        {
            var imageEntity = await _equipmentImageRepository.GetAsync(imageId);

            await _equipmentImageRepository.RemoveAsync(imageEntity);
        }
    }
}