using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Repository;

namespace LexiconLMS.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            var documentRepository = _unitOfWork.GetRepository<Document>();
            return await documentRepository.GetAllAsync();
        }

        public async Task<Document?> GetDocumentAsync(int id)
        {
            var documentRepository = _unitOfWork.GetRepository<Document>();
            return await documentRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Document>> FindDocumentsAsync(string searchString)
        {
            var documentRepository = _unitOfWork.GetRepository<Document>();
            return await documentRepository.FindAsync(d => d.SearchableString.Contains(searchString));
        }

        public async Task AddDocumentAsync(Document document)
        {
            var documentRepository = _unitOfWork.GetRepository<Document>();
            await documentRepository.AddAsync(document);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateDocumentAsync(Document document)
        {
            var documentRepository = _unitOfWork.GetRepository<Document>();
            await documentRepository.UpdateAsync(document);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDocumentAsync(Document document)
        {
            var documentRepository = _unitOfWork.GetRepository<Document>();
            await documentRepository.DeleteAsync(document);
            await _unitOfWork.SaveChangesAsync();
        }
    }


}
