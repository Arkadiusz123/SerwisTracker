using Microsoft.EntityFrameworkCore;
using SerwisTracker.Server.Parts;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerwisTracker.Server.Repairs
{
    [PrimaryKey(nameof(PartId), nameof(RepairId))]
    public class PartRepair
    {
        [Column(Order = 0)]
        public int PartId { get; set; }

        [Column(Order = 1)]
        public int RepairId { get; set; }

        public required Part Part { get; set; }
        public required Repair Repair { get; set; }

        public int PartQuantity { get; set; }
    }
}
