using BossSpotted.Hubs.Interface;
using BossSpotted.Models.BusinessDomain.Sightings;
using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.EntityFrameWork;
using BossSpotted.Models.Interface;
using Microsoft.Win32;

namespace BossSpotted.Models
{
    public class BossSpottedModel : IBossSpottedModel
    {
        private readonly IRegisterNewSighting _registerNewSighting;

        public BossSpottedModel(IRegisterNewSighting registerNewSighting)
        {
            _registerNewSighting = registerNewSighting;
        }

        public bool BossSpotted(int id, int seriousness)
        {
            var sightingSeriousness = MapSightingSeriousness(seriousness);

            var isNewSigthingRegistered = _registerNewSighting.Register(id, sightingSeriousness);

            return isNewSigthingRegistered;
        }

        private static SightingSeriousness MapSightingSeriousness(int seroiusness)
        {
            switch (seroiusness)
            {
                case 1:
                    return SightingSeriousness.green;
                case 2:
                    return SightingSeriousness.yellow;
                case 3:
                    return SightingSeriousness.red;
                default:
                    return SightingSeriousness.red;
            }
        }
    }
}
