using System.ComponentModel.DataAnnotations.Schema;

namespace SerwisTracker.Server.Shared
{
    public interface IHasDbProperties
    {
        DbProperties DbProperties { get; set; }
    }

    [ComplexType]
    public class DbProperties
    {
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Edited { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}
