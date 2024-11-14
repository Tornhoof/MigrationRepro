using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace MigrationRepro
{
    internal class Program
    {
        private const string ConnectionString = "Data Source=localhost;Initial Catalog=MigrationRepoDb;TrustServerCertificate=True;Integrated Security=True";
        static async Task Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder.ConfigureServices(s =>
            {
                s.AddDbContext<MyContext>(o => o.UseSqlServer(ConnectionString));
            });
            var host = hostBuilder.Build();
            using (var scope = host.Services.CreateScope())
            {
                await using var dbContext = scope.ServiceProvider.GetRequiredService<MyContext>();
                await dbContext.Database.EnsureDeletedAsync().ConfigureAwait(false);
                await dbContext.Database.MigrateAsync().ConfigureAwait(false);

            }

            await host.RunAsync();
        }
    }

    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

    }
}
