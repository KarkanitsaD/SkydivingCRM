using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.SkydivingClub;
using SkydivingCRM.SkydivingClubService.Api.Models.ResponseModels.SkydivingClub;
using SkydivingCRM.SkydivingClubService.Business.Models.SkydivingClub;
using SkydivingCRM.SkydivingClubService.Business.Models.User;
using SkydivingCRM.SkydivingClubService.Business.Services.IServices;

namespace SkydivingCRM.SkydivingClubService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkydivingClubController : ControllerBase
    {
        private readonly ISkydivingClubService _skydivingClubService;
        private readonly IMapper _mapper;

        public SkydivingClubController(ISkydivingClubService skydivingClubService, IMapper mapper)
        {
            _skydivingClubService = skydivingClubService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSkydivingClub(RegisterSkydivingClubRequestModel registerClubRequest)
        {
            var clubModel = _mapper.Map<RegisterSkydivingClubRequestModel, SkydivingClubModel>(registerClubRequest);
            var userModel = _mapper.Map<RegisterSkydivingClubRequestModel, UserModel>(registerClubRequest);

            clubModel = await _skydivingClubService.RegisterSkydivingClub(clubModel, userModel, registerClubRequest.ClubAdministratorPassword);

            return Ok(clubModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSkydivingClub([FromBody] UpdateSkydivingClubRequestModel updateSkydivingClubRequest)
        {
            var skydivingClubModel = _mapper.Map<UpdateSkydivingClubRequestModel, SkydivingClubModel>(updateSkydivingClubRequest);

            skydivingClubModel  = await _skydivingClubService.UpdateSkydivingClub(skydivingClubModel);

            return Ok(_mapper.Map<SkydivingClubModel, SkydivingClubResponseModel>(skydivingClubModel));
        }
    }
}