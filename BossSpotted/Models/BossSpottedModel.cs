using BossSpotted.Models.BusinessDomain.Sightings;
using BossSpotted.Models.EntityFramework;

namespace BossSpotted.Models
{
    public class BossSpottedModel
    {
        private readonly ILoggerFactory _IloggerFactory;
        private readonly BossSpottedContext _context;


        public BossSpottedModel(ILoggerFactory iloggerFactory, BossSpottedContext context)
        {
            this._IloggerFactory = iloggerFactory;
            this._context = context;
        }

        public bool BossSpotted(int id, int seriousness)
        {
            RegisterNewSighting registerNewSighting = new RegisterNewSighting(_IloggerFactory, _context);
            SightingSeriousness sightingSeriousness = MapSightingSeriousness(seriousness);

            bool isNewSightingRegistered = registerNewSighting.Register(id, sightingSeriousness);

            return isNewSightingRegistered;
        }

        private static SightingSeriousness MapSightingSeriousness(int seroiusness)
        {
            switch (seroiusness)
            {
                case 0:
                    return SightingSeriousness.green;
                case 1:
                    return SightingSeriousness.yellow;
                case 2:
                    return SightingSeriousness.red;
                default:
                    return SightingSeriousness.red;
            }
        }
    }
}
