using LexiconLMS.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        //Get: api/courses

        [HttpGet]
        public async Task<ActionResult> GetCourses()
        {
            var courses = await _courseService.GetCoursesAsync();
            return Ok(courses);
        }

        //get specific course
        //get: api/courses/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseService.GetCourseAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }


        //post:api/courses
        [HttpPost]
        public async Task<ActionResult> PostCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Course is null.");
            }

            var validationResult = await _courseService.ValidateCourseAsync(course);
            if (!validationResult.Success)
            {
                return BadRequest(validationResult.Errors);
            }

            await _courseService.AddCourseAsync(course);

            return CreatedAtAction(nameof(GetCourses), new { id = course.Id }, course);
        }

        //// PUT: api/courses/{id}
        //[HttpPut("{id}")]
        //public async Task<ActionResult> PutCourse(int id, [FromBody] Course course)
        //{
        //    if (id != course.Id)
        //    {
        //        return BadRequest("Course ID in the URL does not match the course ID in the request body.");
        //    }

        //    var existingCourse = await _courseService.GetCourseAsync(id);
        //    if (existingCourse == null)
        //    {
        //        return NotFound();
        //    }

        //    var validationResult = await _courseService.ValidateCourseAsync(course);
        //    if (!validationResult.Success)
        //    {
        //        return BadRequest(validationResult.Errors);
        //    }

        //    await _courseService.UpdateCourseAsync(course);

        //    return NoContent();
        //}

        // DELETE: api/courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseService.GetCourseAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseService.DeleteCourseAsync(course);

            return NoContent();
        }
    }
}
