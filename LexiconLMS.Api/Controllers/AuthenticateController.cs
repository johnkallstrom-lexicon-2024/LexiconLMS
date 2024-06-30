using LexiconLMS.Core.Models.User;
using LexiconLMS.Core.Results;

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

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginModel model)
        {
            var result = await _userService.LoginUserAsync(model.Email, model.Password);
            return Ok(result);
        }
    }
}
