using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VasilyTest.Core.Helpers;
using VasilyTest.Core.Services;

namespace VasilyTest.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Authenticate([FromBody]User user)
        {
            var token = _authService.Authenticate(user.Username, user.Password);
            return ReturnResult(token);
        }
    }
}