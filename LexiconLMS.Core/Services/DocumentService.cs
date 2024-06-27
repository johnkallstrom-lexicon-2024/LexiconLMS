namespace LexiconLMS.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Document>> GetDocumentsAsync()
        {
            var documents = await _unitOfWork.DocumentRepository.GetListAsync();
            return documents;
        }

        public async Task<Document?> GetDocumentByIdAsync(int id)
        {
            var document = await _unitOfWork.DocumentRepository.GetByIdAsync(id);
            return document;
        }

        public async Task<Document> CreateDocumentAsync(Document document)
        {
            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            var createdDocument = await _unitOfWork.DocumentRepository.CreateAsync(document);
            await _unitOfWork.SaveAsync();

            return createdDocument;
        }

        public async Task UpdateDocumentAsync(Document document)
        {
            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            _unitOfWork.DocumentRepository.Update(document);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDocumentAsync(Document document)
        {
            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            _unitOfWork.DocumentRepository.Delete(document);
            await _unitOfWork.SaveAsync();
        }
    }
}
