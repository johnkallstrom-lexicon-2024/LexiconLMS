namespace LexiconLMS.Persistence.Repositories
{
    public class DocumentRepository : IRepository<Document>
    {
        public Task<Document> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Document?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Document> CreateAsync(Document entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Document entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Document entity)
        {
            throw new NotImplementedException();
        }
    }
}
