using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.UserService.Api.Models.RequestModels.User;
using SkydivingCRM.UserService.Business.Models.User;
using SkydivingCRM.UserService.Business.Services.IServices;

namespace SkydivingCRM.UserService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("addSportsmanToGroup")]
        public async Task<IActionResult> AddSportsmanToGroup([FromBody] AddSportsmanToGroupRequestModel model)
        {
            var skydivingGroupSportsmanModel =
                _mapper.Map<AddSportsmanToGroupRequestModel, SkydivingGroupSportsmanModel>(model);
            await _userService.AddSportsmanToGroup(skydivingGroupSportsmanModel);
            return Ok();
        }

        [HttpPost]
        [Route("addInstructorToGroup")]
        public async Task<IActionResult> AddInstructorToGroup([FromBody] AddInstructorToGroupRequestModel model)
        {
            var skydivingGroupInstructorModel =
                _mapper.Map<AddInstructorToGroupRequestModel, SkydivingGroupInstructorModel>(model);
            await _userService.AddInstructorToGroup(skydivingGroupInstructorModel);
            return Ok();
        }
    }
}