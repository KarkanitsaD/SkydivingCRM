using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkydivingCRM.AuthService.Business.Models;
using SkydivingCRM.AuthService.Business.Services.IServices;

namespace SkydivingCRM.AuthService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel loginModel)
        {
            var result = await _authService.LoginAsync(loginModel);
            return Ok(result);
        }
    }
}