using SerwisTracker.Server.Cars;
using SerwisTracker.Server.Shared;
using SerwisTracker.Server.User;

namespace SerwisTracker.Server.Repairs
{
    public class Repair : IHasDbProperties
    {
        public int RepairId { get; set; }
        public required DateTime Date { get; set; }
        public required int Mileage { get; set; }
        public string Description { get; set; } = "";

        public required Car Car { get; set; }
        public int CarId { get; set; }

        public List<PartRepair> PartRepairs { get; set; } = [];

        public string CreatorId { get; set; }
        public required ApplicationUser Creator { get; set; }

        public DbProperties DbProperties { get; set; } = new DbProperties();
    }
}
