using LexiconLMS.Core.Models.Authenticate;
using LexiconLMS.Core.Results;
using Microsoft.AspNetCore.Authorization;

namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticateController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginUser(AuthenticateRequest model)
        {
            var result = await _userService.LoginUserAsync(model.Email, model.Password);
            if (result.Success)
            {
                return Ok(result.Value);
            }
            else
            {
                return Ok(new { Success = false, Errors = result.Errors });
            }
        }
    }
}
