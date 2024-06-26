namespace LexiconLMS.Persistence.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly LexiconDbContext _context;

        public CourseRepository(LexiconDbContext context)
        {
            _context = context;
        }

        public Task<Course> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> CreateAsync(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
