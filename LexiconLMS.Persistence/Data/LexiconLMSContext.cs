using LexiconLMS.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Data
{
    public class LexiconLMSContext : IdentityDbContext<User, Role, int>
    {
        public LexiconLMSContext(DbContextOptions<LexiconLMSContext> options) : base(options)
        {
        }

        //public DbSet<Activity> Activities { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<Document> Documents { get; set; }
        //public DbSet<Module> Modules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            RenameIdentityTables(builder);
        }

        private void RenameIdentityTables(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
        }
    }
}
