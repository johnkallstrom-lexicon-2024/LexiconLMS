using LexiconLMS.Persistence.Data;

namespace LexiconLMS.Persistence.Repositories
{
    public class ActivityRepository : IRepository<Activity>
    {
        private readonly LexiconDbContext _context;

        public ActivityRepository(LexiconDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Activity>> GetListAsync()
        {
            var activities = await _context.Activities.ToListAsync();
            return activities;
        }

        public async Task<Activity?> GetByIdAsync(int id)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);
            return activity;
        }

        public async Task<Activity> CreateAsync(Activity entity)
        {
            var entry = await _context.Activities.AddAsync(entity);
            return entry.Entity;
        }

        public void Update(Activity entity) => _context.Activities.Update(entity);

        public void Delete(Activity entity) => _context.Activities.Remove(entity);
    }
}
