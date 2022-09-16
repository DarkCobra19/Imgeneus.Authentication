using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imgeneus.Authentication.Entities
{
    [Table("Users")]
    public class DbUser : IdentityUser<int>
    {
        /// <summary>
        /// Gets or sets the user's current points.
        /// </summary>
        public uint Points { get; set; }

        /// <summary>
        /// Gets the user's creation time.
        /// </summary>
        [Column(TypeName = "DATETIME")]
        public DateTime CreateTime { get; private set; }

        /// <summary>
        /// Gets or sets the last time user login.
        /// </summary>
        [Column(TypeName = "DATETIME")]
        public DateTime LastConnectionTime { get; set; }

        /// <summary>
        /// Gets or sets a flag that indicates if the user is deleted.
        /// </summary>
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Creates a new <see cref="DbUser"/> instance.
        /// </summary>
        public DbUser()
        {
            CreateTime = DateTime.UtcNow;
        }
    }
}
