namespace LexiconLMS.Persistence.Repositories
{
    public class ActivityRepository : IRepository<Activity>
    {
        private readonly LexiconDbContext _context;

        public ActivityRepository(LexiconDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Activity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Activity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> CreateAsync(Activity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Activity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Activity entity)
        {
            throw new NotImplementedException();
        }
    }
}
