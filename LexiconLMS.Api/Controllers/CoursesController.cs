namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        //Get: api/courses

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetCoursesAsync();
            return Ok(_mapper.Map<IEnumerable<CourseModel>>(courses));
        }

        //get specific course
        //get: api/courses/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CourseModel>(course));
        }


        //post:api/courses
        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] CourseCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var course = _mapper.Map<Course>(model);
            var createdCourse = await _courseService.CreateCourseAsync(course);

            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, createdCourse);
        }

        // PUT: api/courses/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCourse(int id, [FromBody] CourseUpdateModel model)
        {
            var existingCourse = await _courseService.GetCourseByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse = _mapper.Map(source: model, destination: existingCourse);
            await _courseService.UpdateCourseAsync(existingCourse);

            return NoContent();
        }

        // DELETE: api/courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseService.DeleteCourseAsync(course);

            return NoContent();
        }
    }
}
