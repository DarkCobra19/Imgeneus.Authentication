using Imgeneus.Authentication.Context;
using Imgeneus.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Imgeneus.Authentication.Connection
{
    /// <summary>
    /// Factory used for db migrations.
    /// </summary>
    public class DatabaseFactory : IDesignTimeDbContextFactory<UsersContext>
    {
        public UsersContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
#if DEBUG
                .AddJsonFile($"settings.Development.json", optional: true)
#else
                .AddJsonFile($"settings.Release.json", optional: true)
#endif
                .Build();

            var dbConfig = new UsersDatabaseConfiguration();
            configuration.Bind("UsersDatabase", dbConfig);

            var optionsBuilder = new DbContextOptionsBuilder<UsersContext>();
            optionsBuilder.ConfigureCorrectDatabase(dbConfig);

            return new UsersContext(optionsBuilder.Options);
        }
    }
}
