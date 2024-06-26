namespace LexiconLMS.Persistence.Repositories
{
    public class ModuleRepository : IRepository<Module>
    {
        private readonly LexiconDbContext _context;

        public ModuleRepository(LexiconDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Module>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Module?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Module> CreateAsync(Module entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Module entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Module entity)
        {
            throw new NotImplementedException();
        }
    }
}
