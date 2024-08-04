using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SerwisTracker.Server.Cars;
using SerwisTracker.Server.Parts;
using SerwisTracker.Server.Repairs;
using SerwisTracker.Server.User;

namespace SerwisTracker.Server.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<PartRepair> PartRepairs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>().HasOne(a => a.Creator).WithMany(a => a.Cars).HasForeignKey(a => a.CreatorId);
            builder.Entity<Part>().HasOne(a => a.Creator).WithMany(a => a.Parts).HasForeignKey(a => a.CreatorId);
            builder.Entity<Repair>().HasOne(a => a.Creator).WithMany(a => a.Repairs).HasForeignKey(a => a.CreatorId);

            builder.Entity<ApplicationUser>().HasQueryFilter(u => !u.DbProperties.Deleted);
            builder.Entity<Car>().HasQueryFilter(u => !u.DbProperties.Deleted);
            builder.Entity<Part>().HasQueryFilter(u => !u.DbProperties.Deleted);
            builder.Entity<Repair>().HasQueryFilter(u => !u.DbProperties.Deleted);

            base.OnModelCreating(builder);
        }
    }
}
