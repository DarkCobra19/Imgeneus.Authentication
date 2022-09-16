using Imgeneus.Authentication.Context;
using Imgeneus.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Imgeneus.Authentication.Connection
{
    public static class ConfigureDatabase
    {
        public static DbContextOptionsBuilder ConfigureCorrectDatabase(this DbContextOptionsBuilder optionsBuilder, UsersDatabaseConfiguration configuration)
        {
            optionsBuilder.UseMySql(
                configuration.ToString(),
                new MySqlServerVersion(new Version(8, 0, 22)),
                builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
                });
            return optionsBuilder;
        }

        public static IServiceCollection RegisterUsersDatabaseServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddDbContext<IUsersDatabase, UsersContext>(options =>
                {
                    var dbConfig = serviceCollection.BuildServiceProvider().GetService<IOptions<UsersDatabaseConfiguration>>();
                    options.ConfigureCorrectDatabase(dbConfig.Value);

#if DEBUG
                    options.ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
#endif
                },
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Singleton);
        }
    }
}
