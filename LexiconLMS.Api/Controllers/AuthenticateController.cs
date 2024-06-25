namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public IActionResult Login(AuthenticateModel model)
        {
            return Ok();
        }
    }
}
