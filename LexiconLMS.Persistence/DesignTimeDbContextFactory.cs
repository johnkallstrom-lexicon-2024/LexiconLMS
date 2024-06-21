using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LexiconLMS.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LexiconDbContext>
    {
        public LexiconDbContext CreateDbContext(string[] args)
        {
            var path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath(Path.Combine(path, @"..\LexiconLMS"));
            Console.WriteLine($"Creating design-time context at {path}.");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LexiconDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new LexiconDbContext(builder.Options);
        }
    }
}
