using AutoMapper;
using LexiconLMS.Core.Identity;

namespace LexiconLMS.Api.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(model);

            var id = await _userService.CreateUserAsync(user, model.Password, model.Roles.ToArray());
            return CreatedAtAction(nameof(GetUserById), new { id });
        }
    }
}
