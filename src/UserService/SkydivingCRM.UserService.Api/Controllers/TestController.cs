using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.UserService.Business.Constants;

namespace SkydivingCRM.UserService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = PoliciesConstants.ClubAdministrator)]
        public string Get()
        {
            return "OK";
        }
    }
}