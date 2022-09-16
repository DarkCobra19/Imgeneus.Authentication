using Imgeneus.Authentication.Entities;
using Microsoft.EntityFrameworkCore;

namespace Imgeneus.Authentication.Context
{
    public interface IUsersDatabase
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<DbUser> Users { get; set; }

        /// <summary>
        /// Saves changes to database.
        /// </summary>
        public int SaveChanges();

        /// <summary>
        /// Saves changes to database.
        /// </summary>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Migrate database.
        /// </summary>
        public void Migrate();
    }
}
