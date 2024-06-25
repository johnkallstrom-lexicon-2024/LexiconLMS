using LexiconLMS.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivity()
        {
            var activity = await _activityService.GetActivitiesAsync();
            return Ok(activity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var activity = await _activityService.GetActivityAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }
        [HttpPost]
        public async Task<IActionResult> AddActivity([FromBody]  ActivityModel activityModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activity = new Activity
            {
                Name = activityModel.Name,
                Description = activityModel.Description,
                Type = activityModel.Type,
                StartDate = activityModel.StartDate,
                EndDate = activityModel.EndDate,
                ModuleId = activityModel.ModuleId,
            };

            await _activityService.AddActivityAsync(activity);
            return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] ActivityModel activityModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingActivity = await _activityService.GetActivityAsync(id);
            if (existingActivity == null)
            {
                return NotFound();
            }

            existingActivity.Name = activityModel.Name;
            existingActivity.Description = activityModel.Description;
            existingActivity.Type = activityModel.Type;
            existingActivity.StartDate = activityModel.StartDate;
            existingActivity.EndDate = activityModel.EndDate;
            existingActivity.ModuleId = activityModel.ModuleId;

            await _activityService.UpdateActivityAsync(existingActivity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var activity = await _activityService.GetActivityAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            await _activityService.DeleteActivityAsync(activity);
            return NoContent();
        }

    }
}
