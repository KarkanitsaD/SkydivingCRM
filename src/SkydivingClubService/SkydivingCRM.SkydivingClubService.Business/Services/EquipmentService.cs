using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SkydivingCRM.SkydivingClubService.Business.Models.Equipment;
using SkydivingCRM.SkydivingClubService.Business.Services.IServices;
using SkydivingCRM.SkydivingClubService.Data.Entities;
using SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories;

namespace SkydivingCRM.SkydivingClubService.Business.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentImageRepository _equipmentImageRepository;
        private readonly IMapper _mapper;
        private readonly IMediaService _mediaService;

        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper, IMediaService mediaService, IEquipmentImageRepository equipmentImageRepository)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
            _mediaService = mediaService;
            _equipmentImageRepository = equipmentImageRepository;
        }

        public async Task<EquipmentModel> GetEquipment(Guid equipmentId)
        {
            var equipmentEntity = await _equipmentRepository.GetAsync(equipmentId);

            var equipmentModel = _mapper.Map<EquipmentEntity, EquipmentModel>(equipmentEntity);
            var ids = await _equipmentImageRepository.GetImagesIdsByEquipmentIdAsync(equipmentId);
            equipmentModel.ImagesIds = ids.Select(id => id.ToString()).ToList();

            return equipmentModel;
        }

        public async Task<EquipmentModel> UpdateEquipment(EquipmentModel equipment)
        {
            var equipmentEntity = await _equipmentRepository.GetAsync(equipment.Id);

            equipmentEntity.Title = equipment.Title;

            equipmentEntity = await _equipmentRepository.UpdateAsync(equipmentEntity);

            return _mapper.Map<EquipmentEntity, EquipmentModel>(equipmentEntity);
        }

        public async Task<EquipmentModel> AddEquipment(EquipmentModel equipment, List<string> images)
        {
            var equipmentEntity = _mapper.Map<EquipmentModel, EquipmentEntity>(equipment);

            var equipmentImages = new List<EquipmentImageEntity>();
            foreach (var image in images)
            {
                var mediaModel = _mediaService.GetByteArrayModelFromBase64(image);
                var equipmentImageEntity =
                    new EquipmentImageEntity(mediaModel.Content, mediaModel.Extension, equipmentEntity.Id);
                equipmentImages.Add(equipmentImageEntity);
            }
            equipmentEntity.Images = equipmentImages;

            equipmentEntity = await _equipmentRepository.CreateAsync(equipmentEntity);

            return _mapper.Map<EquipmentEntity, EquipmentModel>(equipmentEntity);
        }

        public async Task<EquipmentModel> DecommissionEquipment(Guid equipmentId)
        {
            var equipmentEntity = await _equipmentRepository.GetAsync(equipmentId);
            equipmentEntity.IsDecommissioned = true;
            equipmentEntity = await _equipmentRepository.UpdateAsync(equipmentEntity);

            return _mapper.Map<EquipmentEntity, EquipmentModel>(equipmentEntity);
        }

        public async Task<EquipmentModel> AssignEquipmentToSportsman(Guid equipmentId, Guid sportsmanId)
        {
            var equipment = await _equipmentRepository.GetAsync(equipmentId);

            equipment.AssignedSportsmanId = sportsmanId;

            equipment = await _equipmentRepository.UpdateAsync(equipment);

            return _mapper.Map<EquipmentEntity, EquipmentModel>(equipment);
        }

        public async Task<EquipmentModel> MoveToAnotherStock(Guid equipmentId, Guid stockId)
        {
            var equipmentEntity = await _equipmentRepository.GetAsync(equipmentId);
            equipmentEntity.StockId = stockId;
            equipmentEntity = await _equipmentRepository.UpdateAsync(equipmentEntity);

            return _mapper.Map<EquipmentEntity, EquipmentModel>(equipmentEntity);
        }

        public async Task RemoveEquipment(Guid equipmentId)
        {
            var equipmentEntity = await _equipmentRepository.GetAsync(equipmentId);
            await _equipmentRepository.RemoveAsync(equipmentEntity);
        }
    }
}