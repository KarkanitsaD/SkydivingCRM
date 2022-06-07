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
        private readonly IMediaService _mediaService;

        public UsersController(IUserService userService, IMapper mapper, IMediaService mediaService)
        {
            _userService = userService;
            _mapper = mapper;
            _mediaService = mediaService;
        }


        [HttpPost]
        [Route("registerSportsman")]
        public async Task<IActionResult> RegisterSportsman([FromBody] RegisterUserRequestModel registerUserModel)
        {
            var userModel = _mapper.Map<UserModel>(registerUserModel);
            await _userService.RegisterSportsman(userModel, registerUserModel.Password);
            return Ok();
        }

        [HttpPost]
        [Route("registerInstructor")]
        public async Task<IActionResult> RegisterInstructor([FromBody] RegisterUserRequestModel registerUserModel)
        {
            var userModel = _mapper.Map<UserModel>(registerUserModel);
            await _userService.RegisterInstructor(userModel, registerUserModel.Password);
            return Ok();
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

        [HttpPost]
        [Route("setUserImage")]
        public async Task<IActionResult> SetUserImage([FromBody] SetUserImageRequestModel setUerImageModel)
        {
            var mediaModel = _mediaService.GetByteArrayModelFromBase64(setUerImageModel.Base64);
            await _userService.SetUserImage(mediaModel, setUerImageModel.UserId);
            return Ok();
        }

        [HttpPost]
        [Route("removeUserImage")]
        public async Task<IActionResult> RemoveImage([FromBody] RemoveUserImageRequestModel removeUserImageModel)
        {
            await _userService.RemoveUserImage(removeUserImageModel.UserId);
            return Ok();
        }
    }
}