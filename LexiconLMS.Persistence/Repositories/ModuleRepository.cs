using LexiconLMS.Persistence.Data;

namespace LexiconLMS.Persistence.Repositories
{
    public class ModuleRepository : IRepository<Module>
    {
        private readonly LexiconDbContext _context;

        public ModuleRepository(LexiconDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Module>> GetListAsync()
        {
            var modules = await _context.Modules.ToListAsync();
            return modules;
        }

        public async Task<Module?> GetByIdAsync(int id)
        {
            var document = await _context.Modules
                .Include(m => m.Course)
                .Include(m => m.Activities)
                .Include(m => m.Documents)
                .FirstOrDefaultAsync(d => d.Id == id);

            return document;
        }

        public async Task<Module> CreateAsync(Module entity)
        {
            var entry = await _context.Modules.AddAsync(entity);
            return entry.Entity;
        }

        public void Update(Module entity) => _context.Modules.Update(entity);
        public void Delete(Module entity) => _context.Modules.Remove(entity);
    }
}
