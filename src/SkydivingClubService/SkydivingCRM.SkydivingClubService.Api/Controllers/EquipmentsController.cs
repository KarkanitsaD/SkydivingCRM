using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.Equipment;
using SkydivingCRM.SkydivingClubService.Api.Models.ResponseModels.Equipment;
using SkydivingCRM.SkydivingClubService.Business.Models.Equipment;
using SkydivingCRM.SkydivingClubService.Business.Services.IServices;

namespace SkydivingCRM.SkydivingClubService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IMapper _mapper;

        public EquipmentsController(IEquipmentService equipmentService, IMapper mapper)
        {
            _equipmentService = equipmentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{equipmentId:guid}")]
        public async Task<IActionResult> GetEquipment([FromRoute] Guid equipmentId)
        {
            var equipmentModel = await _equipmentService.GetEquipment(equipmentId);

            return Ok(_mapper.Map<EquipmentModel, EquipmentResponseModel>(equipmentModel));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEquipment([FromBody] UpdateEquipmentRequestModel updateEquipmentRequest)
        {
            var equipmentModel = _mapper.Map<UpdateEquipmentRequestModel, EquipmentModel>(updateEquipmentRequest);

            equipmentModel = await _equipmentService.UpdateEquipment(equipmentModel);

            return Ok(_mapper.Map<EquipmentModel, EquipmentResponseModel>(equipmentModel));
        }

        [HttpDelete]
        [Route("{equipmentId:guid}")]
        public async Task<IActionResult> RemoveEquipment([FromRoute] Guid equipmentId)
        {
            await _equipmentService.RemoveEquipment(equipmentId);
            return Ok();
        }
    }
}