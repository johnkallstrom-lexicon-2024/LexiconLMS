namespace LexiconLMS.Persistence.Repositories
{
    public class ActivityRepository : IRepository<Activity>
    {
        public Task<Activity> GetListAsync()
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

        public Task UpdateAsync(Activity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Activity entity)
        {
            throw new NotImplementedException();
        }
    }
}
