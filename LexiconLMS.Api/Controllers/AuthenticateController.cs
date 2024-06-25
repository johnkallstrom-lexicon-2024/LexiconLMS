namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
