using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.UserService.Api.Models.RequestModels.User;
using SkydivingCRM.UserService.Business.Models.Auth;
using SkydivingCRM.UserService.Business.Models.User;
using SkydivingCRM.UserService.Business.Services.IServices;

namespace SkydivingCRM.UserService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IMapper mapper, IAuthService authService)
        {
            _userService = userService;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestModel model)
        {
            var userModel = _mapper.Map<RegisterUserRequestModel, UserModel>(model);
             await _authService.RegisterClubAdministrator(userModel, model.Password);
             return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestModel model)
        {
            var loginModel = _mapper.Map<LoginModel>(model);
            return Ok(await _authService.Login(loginModel));
        }

        [HttpGet]
        [Route("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string code)
        {
            Console.Write(userId + " " + code);
            return Ok();
        }
    }
}