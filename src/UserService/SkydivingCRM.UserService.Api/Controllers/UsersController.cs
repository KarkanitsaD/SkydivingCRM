using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.UserService.Api.Models.RequestModels.User;
using SkydivingCRM.UserService.Business.Services.IServices;

namespace SkydivingCRM.UserService.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("addSportsmanToGroup")]
        public async Task<IActionResult> AddSportsmanToGroup([FromBody] AddSportsmanToGroupRequestModel model)
        {

            return Ok();
        }
    }
}