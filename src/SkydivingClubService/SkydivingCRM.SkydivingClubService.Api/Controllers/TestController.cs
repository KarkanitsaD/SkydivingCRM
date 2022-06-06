using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.AuthCommon;

namespace SkydivingCRM.SkydivingClubService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = RolesConstants.SportsmanRole)]
        public string Get()
        {
            var u = User;
            var c = u.Claims.ToList();
            return "Ok";
        }
    }
}