namespace LexiconLMS.Persistence.Repositories
{
    public class ModuleRepository : IRepository<Module>
    {
        private readonly LexiconDbContext _context;

        public ModuleRepository(LexiconDbContext context)
        {
            _context = context;
        }

        public Task<Module> CreateAsync(Module entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Module entity)
        {
            throw new NotImplementedException();
        }

        public Task<Module?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Module> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Module entity)
        {
            throw new NotImplementedException();
        }
    }
}
