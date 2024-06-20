using LexiconLMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LexiconLMS.Persistence.EntityConfigurations
{
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.ToTable("Modules");
            builder.HasKey(m => m.Id);

            // Module One-to-Many relationship with Activity
            builder
                .HasMany(m => m.Activities)
                .WithOne(a => a.Module)
                .HasForeignKey(a => a.ModuleId);
        }
    }
}
