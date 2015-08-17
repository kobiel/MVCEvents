using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MVCEvents.Models
{
    public class MVCEventDbContext : IdentityDbContext<ApplicationUser>
    {
        public MVCEventDbContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// List of users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// List of guest
        /// </summary>
        public DbSet<Guest> Guests { get; set; }

        /// <summary>
        /// List of events
        /// </summary>
        public DbSet<Event> Events { get; set; }
    }
}
