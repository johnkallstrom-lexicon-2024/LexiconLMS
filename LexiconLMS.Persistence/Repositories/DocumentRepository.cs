using LexiconLMS.Persistence.Data;

namespace LexiconLMS.Persistence.Repositories
{
    public class DocumentRepository : IRepository<Document>
    {
        private readonly LexiconDbContext _context;

        public DocumentRepository(LexiconDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Document>> GetListAsync()
        {
            var documents = await _context.Documents
                .Include(d => d.User)
                .ToListAsync();

            return documents;
        }

        public async Task<Document?> GetByIdAsync(int id)
        {
            var document = await _context.Documents
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.Id == id);

            return document;
        }

        public async Task<Document> CreateAsync(Document entity)
        {
            var entry = await _context.Documents.AddAsync(entity);
            return entry.Entity;
        }

        public void Update(Document entity) => _context.Documents.Update(entity);
        public void Delete(Document entity) => _context.Documents.Remove(entity);
    }
}
