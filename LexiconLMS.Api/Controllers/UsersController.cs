using AutoMapper;
using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Identity;

namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;

        public UsersController(IUserService userService, IMapper mapper, ICourseService courseService)
        {
            _userService = userService;
            _mapper = mapper;
            _courseService = courseService;
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

            if (model.CourseId.HasValue)
            {
                Course? course = await _courseService.GetCourseAsync(model.CourseId.Value);
                if (course is null)
                {
                    return BadRequest(new { Message = $"The course with id {model.CourseId.Value} does not exist" });
                }
            }

            var user = _mapper.Map<User>(model);

            var createdUser = await _userService.CreateUserAsync(user, model.Password, model.Roles.ToArray());
            return CreatedAtAction(nameof(GetUserById), new { user.Id }, createdUser);
        }
    }
}
