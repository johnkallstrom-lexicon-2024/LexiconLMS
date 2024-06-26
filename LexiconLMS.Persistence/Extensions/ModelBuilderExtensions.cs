using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void RenameIdentityTables(this ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
        }
    }
}
