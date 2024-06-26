using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LexiconLMS.Persistence.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
        }
    }
}
