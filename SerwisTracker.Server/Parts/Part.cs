using Microsoft.EntityFrameworkCore;
using SerwisTracker.Server.Repairs;
using SerwisTracker.Server.Shared;
using SerwisTracker.Server.User;

namespace SerwisTracker.Server.Parts
{
    [Index(nameof(PartNumber), nameof(CreatorId), IsUnique = true)]
    public class Part : IHasDbProperties
    {
        public int PartId { get; set; }
        public required string Description { get; set; }
        public required string PartNumber { get; set; }

        public List<PartRepair> PartRepairs { get; set; } = [];

        public string CreatorId { get; set; }
        public required ApplicationUser Creator { get; set; }

        public DbProperties DbProperties { get; set; } = new DbProperties();
    }
}
