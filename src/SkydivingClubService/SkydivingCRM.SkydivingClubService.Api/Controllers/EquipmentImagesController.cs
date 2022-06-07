using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.EquipmentImage;
using SkydivingCRM.SkydivingClubService.Business.Services.IServices;

namespace SkydivingCRM.SkydivingClubService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentImagesController : ControllerBase
    {
        private readonly IEquipmentImageService _equipmentImageService;

        public EquipmentImagesController(IEquipmentImageService equipmentImageService)
        {
            _equipmentImageService = equipmentImageService;
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(AddEquipmentImageRequestModel imageRequestModel)
        {
            await _equipmentImageService.AddImage(imageRequestModel.EquipmentId, imageRequestModel.Base64);
            return Ok();
        }

        [HttpDelete]
        [Route("{imageId:guid}")]
        public async Task<IActionResult> RemoveImage([FromRoute] Guid imageId)
        {
            await _equipmentImageService.RemoveImage(imageId);
            return Ok();
        }
    }
}