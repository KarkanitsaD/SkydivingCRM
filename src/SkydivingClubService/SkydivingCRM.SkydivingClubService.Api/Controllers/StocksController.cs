using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.Stock;
using SkydivingCRM.SkydivingClubService.Api.Models.ResponseModels.Equipment;
using SkydivingCRM.SkydivingClubService.Api.Models.ResponseModels.Stock;
using SkydivingCRM.SkydivingClubService.Business.Models.Equipment;
using SkydivingCRM.SkydivingClubService.Business.Models.Stock;
using SkydivingCRM.SkydivingClubService.Business.Services.IServices;

namespace SkydivingCRM.SkydivingClubService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public StocksController(IStockService stockService, IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{stockId:guid}/equipments")]
        public async Task<IActionResult> GetStockEquipments([FromBody] Guid stockId)
        {
            var equipmentModels = await _stockService.GetEquipmentsByStockId(stockId);
            return Ok(_mapper.Map<List<EquipmentModel>, List<EquipmentResponseModel>>(equipmentModels));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockRequestModel createStockRequest)
        {
            var stockModel = _mapper.Map<CreateStockRequestModel, StockModel>(createStockRequest);
            stockModel = await _stockService.CreateStock(stockModel);
            return Ok(_mapper.Map<StockModel, StockResponseModel>(stockModel));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStockRequestModel updateStockRequest)
        {
            var stockModel = _mapper.Map<UpdateStockRequestModel, StockModel>(updateStockRequest);
            stockModel = await _stockService.UpdateStock(stockModel);
            return Ok(_mapper.Map<StockModel, StockResponseModel>(stockModel));
        }
    }
}