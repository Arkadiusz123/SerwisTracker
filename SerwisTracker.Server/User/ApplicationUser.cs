using Microsoft.AspNetCore.Identity;
using SerwisTracker.Server.Shared;

namespace SerwisTracker.Server.User
{
    public class ApplicationUser : IdentityUser, IHasDbProperties
    {
        public DbProperties DbProperties { get; set; } = new DbProperties();
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
