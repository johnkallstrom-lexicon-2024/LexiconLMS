namespace LexiconLMS.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LexiconDbContext _context;

        public UnitOfWork(LexiconDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
