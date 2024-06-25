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
            return Ok(_mapper.Map<IEnumerable<UserModel>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserModel>(user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateModel model)
        {
            if (model.CourseId.HasValue)
            {
                Course? course = await _courseService.GetCourseAsync(model.CourseId.Value);
                if (course is null)
                {
                    return BadRequest(new { Message = $"The course with id {model.CourseId.Value} does not exist" });
                }
            }

            var user = _mapper.Map<User>(model);

            var result = await _userService.CreateUserAsync(user, model.Password, model.Roles.ToArray());
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            var result = await _userService.DeleteUserAsync(user);
            return Ok(result);
        }
    }
}
