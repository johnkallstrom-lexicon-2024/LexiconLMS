using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LexiconLMS.Persistence.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(c => c.Id);

            // Course One-to-Many relationship with Module
            builder
                .HasMany(c => c.Modules)
                .WithOne(m => m.Course)
                .HasForeignKey(m => m.CourseId);

            builder.Property(c => c.Created).ValueGeneratedOnAdd();
            builder.Property(c => c.LastModified).ValueGeneratedOnUpdate();
        }
    }
}
