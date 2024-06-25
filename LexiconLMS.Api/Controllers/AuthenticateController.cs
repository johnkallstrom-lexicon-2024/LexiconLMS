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
        public async Task<IActionResult> Login(AuthenticateModel model)
        {
            var result = await _userService.LoginWithEmailAsync(model.Email, model.Password);
            return Ok(result);
        }
    }
}
