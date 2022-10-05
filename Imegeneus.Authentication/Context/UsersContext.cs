using Imgeneus.Authentication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Imgeneus.Authentication.Context
{
    public class UsersContext : IdentityDbContext<DbUser, DbRole, int>, IUsersDatabase
    {
        public DbSet<DbShopItem> ShopItems { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {

        }

        public void Migrate()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>().HasIndex(c => new { c.UserName, c.Email }).IsUnique();

            base.OnModelCreating(modelBuilder);

            // Get rid of "aspnet" prefix in table names
            var tableNamePrefix = "AspNet";
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith(tableNamePrefix))
                    entityType.SetTableName(tableName.Substring(tableNamePrefix.Length));
            }
        }
    }
}
