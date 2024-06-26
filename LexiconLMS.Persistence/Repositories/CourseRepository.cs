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

        public async Task<Course?> GetByIdAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            return course;
        }

        public async Task<Course> CreateAsync(Course entity)
        {
            var entry = await _context.Courses.AddAsync(entity);
            return entry.Entity;
        }

        public void Update(Course entity) => _context.Update(entity);

        public void Delete(Course entity) => _context.Remove(entity);
    }
}
