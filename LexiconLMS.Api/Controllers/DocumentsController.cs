namespace LexiconLMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var documents = await _documentService.GetDocumentsAsync();
            return Ok(_mapper.Map<IEnumerable<DocumentModel>>(documents));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            var document = await _documentService.GetDocumentByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DocumentModel>(document));
        }

        [HttpPost]
        public async Task<IActionResult> AddDocument([FromBody] DocumentModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var document = new Document
            //{
            //    Name = model.Name,
            //    Description = model.Description,
            //    UploadTime = model.UploadTime,
            //    UserId = model.UserId,
            //    CourseId = model.CourseId,
            //    ModuleId = model.ModuleId,
            //    ActivityId = model.ActivityId
            //};

            //await _documentService.AddDocumentAsync(document);

            //return CreatedAtAction(nameof(GetDocumentById), new { id = document.Id }, document);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] DocumentModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var existingDocument = await _documentService.GetDocumentAsync(id);
            //if (existingDocument == null)
            //{
            //    return NotFound();
            //}

            //existingDocument.Name = model.Name;
            //existingDocument.Description = model.Description;
            //existingDocument.UploadTime = model.UploadTime;
            //existingDocument.UserId = model.UserId;
            //existingDocument.CourseId = model.CourseId;
            //existingDocument.ModuleId = model.ModuleId;
            //existingDocument.ActivityId = model.ActivityId;

            //await _documentService.UpdateDocumentAsync(existingDocument);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var document = await _documentService.GetDocumentByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            await _documentService.DeleteDocumentAsync(document);
            return NoContent();
        }
    }
}

