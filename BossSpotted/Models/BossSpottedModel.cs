using BossSpotted.Hubs.Interface;
using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.EntityFrameWork;
using BossSpotted.Models.Interface;

namespace BossSpotted.Models
{
    public class BossSpottedModel : IBossSpottedModel
    {
        private readonly IBossSpottedHub _bossSpottedHub;

        public BossSpottedModel(IBossSpottedHub bossSpottedHub)
        {
            _bossSpottedHub = bossSpottedHub;
        }

        public async Task BossSpotted(int id, int seriousness)
        {
            var personEntity = new Person()
            {
                Id = id,
            };

            var sightingSeriousness = new SightingSeriousness()
            {
                Id = 1,
                Seriousness = (Seriousness)1,
            };

            var sighting = new Sighting()
            {
                Id = 1,
                PersonSighted = personEntity,
                SightingSeriousness = sightingSeriousness
            };



            await _bossSpottedHub.BossSpotted();
        }
    }
}
