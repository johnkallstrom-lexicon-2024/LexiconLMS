namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IActionResult GetUsers()
        {
            return Ok();
        }
    }
}
