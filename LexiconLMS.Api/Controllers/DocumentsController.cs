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
            return Ok(_mapper.Map<IEnumerable<DocumentTrimModel>>(documents));
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
        public async Task<IActionResult> CreateDocument([FromBody] DocumentCreateModel model)
        {
            var document = _mapper.Map<Document>(model);
            var createdDocument = await _documentService.CreateDocumentAsync(document);

            return CreatedAtAction(nameof(GetDocumentById), new { id = document.Id }, createdDocument);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] DocumentUpdateModel model)
        {
            var existingDocument = await _documentService.GetDocumentByIdAsync(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            existingDocument = _mapper.Map(source: model, destination: existingDocument);
            await _documentService.UpdateDocumentAsync(existingDocument);

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

