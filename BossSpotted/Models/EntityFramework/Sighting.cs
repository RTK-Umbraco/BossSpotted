using BossSpotted.Models.EntityFrameWork;
using BossSpotted.Models.Interface;

namespace BossSpotted.Models.EntityFramework
{
    public partial class Sighting : IDbModel
    {
        public DateTime CreatedTimeStamp { get ; set ; } = DateTime.Now.ToUniversalTime();
        public DateTime? DeletedTimeStamp { get; set; }
        public int Id { get; set; }
        public Person PersonSighted { get; set; }
        public SightingSeriousness SightingSeriousness { get; set; }
        
    }
}
