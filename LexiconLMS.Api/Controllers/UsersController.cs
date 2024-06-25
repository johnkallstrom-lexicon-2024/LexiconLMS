namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IActivityService activityService)
        {
            _userService = userService;
            _activityService = activityService;
        }

        [HttpGet("/activities")]
        public async Task<IActionResult> GetActivities()
        {
            var data = await _activityService.GetActivitiesAsync();

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
