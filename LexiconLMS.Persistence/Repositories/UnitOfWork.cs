using LexiconLMS.Persistence.Data;

namespace LexiconLMS.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LexiconDbContext _context;

        public UnitOfWork(LexiconDbContext context)
        {
            _context = context;

            ActivityRepository = new ActivityRepository(_context);
            CourseRepository = new CourseRepository(_context);
            DocumentRepository = new DocumentRepository(_context);
            ModuleRepository = new ModuleRepository(_context);
        }

        public IRepository<Activity> ActivityRepository { get; }
        public IRepository<Course> CourseRepository { get; }
        public IRepository<Document> DocumentRepository { get; }
        public IRepository<Module> ModuleRepository { get; }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
