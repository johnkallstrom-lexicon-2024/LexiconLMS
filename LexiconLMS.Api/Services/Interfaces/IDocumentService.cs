using LexiconLMS.Core.Entities;
using System.Linq.Expressions;

namespace LexiconLMS.Core.Services
{
    public interface IDocumentService
    {
        Task AddDocumentAsync(Document document);
        Task DeleteDocumentAsync(Document document);
        Task<IEnumerable<Document>> FindDocumentAsync(Expression<Func<Document, bool>> predicate);
        Task<IEnumerable<Document>> FindDocumentsAsync(string searchString);
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<TEntity?> GetDependency<TEntity>(int id) where TEntity : BaseEntity;
        Task<Document?> GetDocumentAsync(int id);
        Task<IEnumerable<Document>> GetDocumentsByActivityAsync(int activityId);
        Task<IEnumerable<Document>> GetDocumentsByCourseAsync(int courseId);
        Task<IEnumerable<Document>> GetDocumentsByCriteriaAsync(Expression<Func<Document, bool>> criteria);
        Task<IEnumerable<Document>> GetDocumentsByModuleAsync(int moduleId);
        Task<IEnumerable<Document>> GetDocumentsByUserAsync(int userId);
        Task UpdateDocumentAsync(Document document);
    }
}