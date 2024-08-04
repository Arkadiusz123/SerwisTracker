using Microsoft.AspNetCore.Identity;
using SerwisTracker.Server.Cars;
using SerwisTracker.Server.Parts;
using SerwisTracker.Server.Repairs;
using SerwisTracker.Server.Shared;

namespace SerwisTracker.Server.User
{
    public class ApplicationUser : IdentityUser, IHasDbProperties
    {
        public List<Car> Cars { get; set; } = [];
        public List<Part> Parts { get; set; } = [];
        public List<Repair> Repairs { get; set; } = [];

        public DbProperties DbProperties { get; set; } = new DbProperties();
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
