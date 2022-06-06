using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.AuthCommon;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {

        private readonly RoleManager<RoleEntity> _roleManager;

        public RoleController(RoleManager<RoleEntity> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("ClubAdministrator")]
        public async Task<IActionResult> CreateDirectorRole()
        {
            await _roleManager.CreateAsync(new RoleEntity() { Name = RolesConstants.ClubAdministratorRole });
            return Ok();
        }

        [HttpPost]
        [Route("Instructor")]
        public async Task<IActionResult> CreateInstructorRole()
        {
            await _roleManager.CreateAsync(new RoleEntity() { Name = RolesConstants.InstructorRole });
            return Ok();
        }

        [HttpPost]
        [Route("Sportsman")]
        public async Task<IActionResult> CreateSportsmanRole()
        {
            await _roleManager.CreateAsync(new RoleEntity() { Name = RolesConstants.SportsmanRole });
            return Ok();
        }
    }
}