using LexiconLMS.Core.Entities;

namespace LexiconLMS.Core.Interfaces
{
    public interface IDocumentService
    {
        Task AddDocumentAsync(Document document);
        Task DeleteDocumentAsync(Document document);
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<Document?> GetDocumentAsync(int id);
        Task UpdateDocumentAsync(Document document);
    }
}