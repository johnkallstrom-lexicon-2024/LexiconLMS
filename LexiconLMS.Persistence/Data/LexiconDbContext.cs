using LexiconLMS.Persistence.Extensions;

namespace LexiconLMS.Persistence.Data
{
    public class LexiconDbContext : IdentityDbContext<User, Role, int>
    {
        public LexiconDbContext(DbContextOptions<LexiconDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Module> Modules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            builder.RenameIdentityTables();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && e.State == EntityState.Added || e.State == EntityState.Unchanged)
                .ToList();

            foreach (var entry in entries)
            {
                var entity = entry.Entity as BaseEntity;
                if (entity != null)
                {
                    if (entry.State == EntityState.Added) entity.Created = DateTime.Now;
                    if (entry.State == EntityState.Modified) entity.LastModified = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
