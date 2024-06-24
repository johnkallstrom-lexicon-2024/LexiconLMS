using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Exceptions;
using LexiconLMS.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _documentRepository.Entities
                .AsNoTracking()
                .Include(d => d.User)
                .Include(d => d.Course)
                .Include(d => d.Module)
                .Include(d => d.Activity)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Document?> GetDocumentAsync(int id)
        {
            return await _documentRepository.Entities
                .AsNoTracking()
                .Include(d => d.User)
                .Include(d => d.Course)
                .Include(d => d.Module)
                .Include(d => d.Activity)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Document>> GetDocumentsByCriteriaAsync(Expression<Func<Document, bool>> criteria)
        {
            return await _documentRepository.Entities
                .AsNoTracking()
                .Where(criteria)
                .Include(d => d.User)
                .Include(d => d.Course)
                .Include(d => d.Module)
                .Include(d => d.Activity)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document>> FindDocumentsAsync(string searchString)
        {
            return await _documentRepository.Entities
                .AsNoTracking()
                .Where(d => EF.Functions.Like(d.SearchableString, $"%{searchString}%"))
                .Include(d => d.User)
                .Include(d => d.Course)
                .Include(d => d.Module)
                .Include(d => d.Activity)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document>> GetDocumentsByUserAsync(int userId)
        {
            return await _documentRepository.FindAsync(d => d.UserId == userId);
        }

        public async Task<IEnumerable<Document>> GetDocumentsByCourseAsync(int courseId)
        {
            return await _documentRepository.FindAsync(d => d.CourseId == courseId);
        }

        public async Task<IEnumerable<Document>> GetDocumentsByModuleAsync(int moduleId)
        {
            return await _documentRepository.FindAsync(d => d.ModuleId == moduleId);
        }

        public async Task<IEnumerable<Document>> GetDocumentsByActivityAsync(int activityId)
        {
            return await _documentRepository.FindAsync(d => d.ActivityId == activityId);
        }

        public async Task<TEntity?> GetDependency<TEntity>(int id) where TEntity : BaseEntity
        {
            var repository = _unitOfWork.GetRepository<TEntity>();
            return await repository?.GetAsync(id)!;
        }

        public async Task<IEnumerable<Document>> FindDocumentAsync(Expression<Func<Document, bool>> predicate)
        {
            return await _documentRepository.FindAsync(predicate);
        }

        public async Task AddDocumentAsync(Document document)
        {
            await _documentRepository.AddAsync(document);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateDocumentAsync(Document document)
        {
            await _documentRepository.UpdateAsync(document);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDocumentAsync(Document document)
        {
            await _documentRepository.DeleteAsync(document);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
