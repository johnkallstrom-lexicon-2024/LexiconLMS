using LexiconLMS.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var documents = await _documentService.GetAllDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            var document = await _documentService.GetDocumentAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpPost]
        public async Task<IActionResult> AddDocument([FromBody] DocumentModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var document = new Document
            {
                Name = model.Name,
                Description = model.Description,
                UploadTime = model.UploadTime,
                UserId = model.UserId,
                CourseId = model.CourseId,
                ModuleId = model.ModuleId,
                ActivityId = model.ActivityId
            };

            await _documentService.AddDocumentAsync(document);

            return CreatedAtAction(nameof(GetDocumentById), new { id = document.Id }, document);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] DocumentModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingDocument = await _documentService.GetDocumentAsync(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            existingDocument.Name = model.Name;
            existingDocument.Description = model.Description;
            existingDocument.UploadTime = model.UploadTime;
            existingDocument.UserId = model.UserId;
            existingDocument.CourseId = model.CourseId;
            existingDocument.ModuleId = model.ModuleId;
            existingDocument.ActivityId = model.ActivityId;

            await _documentService.UpdateDocumentAsync(existingDocument);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var document = await _documentService.GetDocumentAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            await _documentService.DeleteDocumentAsync(document);
            return NoContent();
        }
    }
}

