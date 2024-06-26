using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Exceptions;
using LexiconLMS.Core.Repository;

namespace LexiconLMS.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Document> _documentRepository;

        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _documentRepository = _unitOfWork.GetRepository<Document>() ?? throw new RepositoryNotFoundException("Document");
        }
    }
}
