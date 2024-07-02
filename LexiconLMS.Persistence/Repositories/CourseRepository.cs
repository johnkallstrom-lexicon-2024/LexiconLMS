using LexiconLMS.Persistence.Data;
using System.Linq.Expressions;

namespace LexiconLMS.Persistence.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly LexiconDbContext _context;

        public CourseRepository(LexiconDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetListAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses;
        }

        public Task<IEnumerable<Course>> GetFilteredAsync(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Users)
                .Include(c => c.Modules)
                .Include(c => c.Documents)
                .FirstOrDefaultAsync(c => c.Id == id);

            return course;
        }

        public async Task<Course> CreateAsync(Course entity)
        {
            var entry = await _context.Courses.AddAsync(entity);
            return entry.Entity;
        }

        public void Update(Course entity) => _context.Courses.Update(entity);
        public void Delete(Course entity) => _context.Courses.Remove(entity);

        public Task<IEnumerable<Activity>> GetActivitiesByModuleIdAsync(int moduleId)
        {
            throw new NotImplementedException();
        }
    }
}
