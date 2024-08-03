using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SerwisTracker.Server.User;

namespace SerwisTracker.Server.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Activity>().HasOne(a => a.Creator).WithMany(a => a.CreatedActivities).HasForeignKey(a => a.CreatorId);

            builder.Entity<ApplicationUser>().HasQueryFilter(u => !u.DbProperties.Deleted);

            base.OnModelCreating(builder);
        }
    }
}
