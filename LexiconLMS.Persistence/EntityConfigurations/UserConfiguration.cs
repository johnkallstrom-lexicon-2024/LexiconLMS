using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LexiconLMS.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // User One-to-Many relationship with Course
            builder
                .HasOne(u => u.Course)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CourseId)
                .IsRequired(false);
        }
    }
}
