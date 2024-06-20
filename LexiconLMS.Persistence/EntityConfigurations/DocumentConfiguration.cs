using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LexiconLMS.Persistence.EntityConfigurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Documents");
            builder.HasKey(d => d.Id);

            // Document One-to-Many relationship with User
            builder
                .HasOne(d => d.User)
                .WithMany(u => u.Documents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Document One-to-Many relationship with Course
            builder
                .HasOne(d => d.Course)
                .WithMany(c => c.Documents)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            // Document One-to-Many relationship with Module
            builder
                .HasOne(d => d.Module)
                .WithMany(c => c.Documents)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.NoAction);

            // Document One-to-Many relationship with Activity
            builder
                .HasOne(d => d.Activity)
                .WithMany(a => a.Documents)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
