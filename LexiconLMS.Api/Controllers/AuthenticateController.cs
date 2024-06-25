namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(AuthenticateModel model)
        {
            return Ok();
        }
    }
}
