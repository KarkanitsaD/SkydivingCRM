using System;
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
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public async Task<EquipmentModel> GetEquipment(Guid equipmentId)
        {
            var equipmentEntity = await _equipmentRepository.GetAsync(equipmentId);
            return _mapper.Map<EquipmentEntity, EquipmentModel>(equipmentEntity);
        }

        public async Task<EquipmentModel> UpdateEquipment(EquipmentModel equipment)
        {
            var equipmentEntity = await _equipmentRepository.GetAsync(equipment.Id);

            equipmentEntity.Title = equipment.Title;

            equipmentEntity = await _equipmentRepository.UpdateAsync(equipmentEntity);

            return _mapper.Map<EquipmentEntity, EquipmentModel>(equipmentEntity);
        }

        public async Task<EquipmentModel> AddEquipment(EquipmentModel equipment)
        {
            var equipmentEntity = _mapper.Map<EquipmentModel, EquipmentEntity>(equipment);

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