using BossSpotted.Models.Interface;

namespace BossSpotted.Models.EntityFramework
{
    public partial class SightingSeriousness : IDbModel
    {
        public DateTime CreatedTimeStamp { get; set; } = DateTime.Now.ToUniversalTime();
        public DateTime? DeletedTimeStamp { get; set; }
        public int Id { get; set; }
        public Seriousness Seriousness { get; set; }
    }

    public enum Seriousness
    {
        green = 0,
        yellow = 1,
        red = 2,
    }
}
