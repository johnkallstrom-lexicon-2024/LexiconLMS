using LexiconLMS.Api.Authorization;
using LexiconLMS.Core.Identity;
using LexiconLMS.Core.Models.User;

namespace LexiconLMS.Api.Controllers
{
    [IsAuthorized]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] UserQueryParams parameters)
        {
            IEnumerable<User> users = default!;

            if (parameters is null) users = await _userService.GetUsersAsync();
            else users = await _userService.GetUsersAsync(parameters);

            var data = new List<UserTrimModel>();
            foreach (var user in users)
            {
                var model = _mapper.Map<UserTrimModel>(user);
                model.Roles = await _userService.GetUserRolesAsync(user);
                data.Add(model);
            }

            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            var model = _mapper.Map<UserModel>(user);
            model.Roles = await _userService.GetUserRolesAsync(user);

            return Ok(model);
        }
    }
}
