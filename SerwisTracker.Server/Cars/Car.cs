using Microsoft.EntityFrameworkCore;
using SerwisTracker.Server.Shared;
using SerwisTracker.Server.User;

namespace SerwisTracker.Server.Cars
{
    [Index(nameof(LicensePlate), nameof(CreatorId), IsUnique = true)]
    public class Car : IHasDbProperties
    {
        public int CarId { get; set; }        
        public required string LicensePlate { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required string Engine { get; set; }
        public required int ManufacturedYear { get; set; }


        public string CreatorId { get; set; }
        public required ApplicationUser Creator { get; set; }

        public DbProperties DbProperties { get; set; } = new DbProperties();
    }
}
