using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SkydivingCRM.SkydivingClubService.Business.Models.Equipment;
using SkydivingCRM.SkydivingClubService.Business.Models.Stock;
using SkydivingCRM.SkydivingClubService.Business.Services.IServices;
using SkydivingCRM.SkydivingClubService.Data.Entities;
using SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories;

namespace SkydivingCRM.SkydivingClubService.Business.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public StockService(IStockRepository stockRepository, IMapper mapper, IEquipmentRepository equipmentRepository)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
            _equipmentRepository = equipmentRepository;
        }

        public async Task<StockModel> CreateStock(StockModel stock)
        {
            var stockEntity = _mapper.Map<StockModel, StockEntity>(stock);
            stockEntity = await _stockRepository.CreateAsync(stockEntity);
            return _mapper.Map<StockEntity, StockModel>(stockEntity);
        }

        public async Task ClearStock(Guid stockId)
        {
            var equipments = await _equipmentRepository.GetAllByStockIdAsync(stockId);
            await _equipmentRepository.RemoveRangeAsync(equipments);
        }

        public async Task<StockModel> UpdateStock(StockModel stock)
        {
            var stockEntity = await _stockRepository.GetAsync(stock.Id);
            stockEntity.Title = stock.Title;
            stockEntity = await _stockRepository.UpdateAsync(stockEntity);
            return _mapper.Map<StockEntity, StockModel>(stockEntity);
        }

        public async Task<List<EquipmentModel>> GetEquipmentsByStockId(Guid stockId)
        {
            var equipmentEntities = await _equipmentRepository.GetAllByStockIdAsync(stockId);
            return _mapper.Map<List<EquipmentEntity>, List<EquipmentModel>>(equipmentEntities);
        }
    }
}