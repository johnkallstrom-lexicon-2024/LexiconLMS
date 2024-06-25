using LexiconLMS.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LexiconLMS.Api.Models;

namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModulesController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetModules()
        {
            var modules = await _moduleService.GetModulesAsync();
            return Ok(modules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModuleById(int id)
        {
            var module = await _moduleService.GetModuleAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map ModuleCreateModel to Module entity
            var module = new Module
            {
                Name = model.Name,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CourseId = model.CourseId,
            };

            await _moduleService.AddModuleAsync(module);

            return CreatedAtAction(nameof(GetModuleById), new { Id = module.Id }, module);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(int id, [FromBody] ModuleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingModule = await _moduleService.GetModuleAsync(id);
            if (existingModule == null)
            {
                return NotFound();
            }

            existingModule.Name = model.Name;
            existingModule.Description = model.Description;
            existingModule.StartDate = model.StartDate;
            existingModule.EndDate = model.EndDate;
            existingModule.CourseId = model.CourseId;

            await _moduleService.UpdateModuleAsync(existingModule);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var module = await _moduleService.GetModuleAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            await _moduleService.DeleteModuleAsync(module);
            return NoContent();
        }
    }
}
