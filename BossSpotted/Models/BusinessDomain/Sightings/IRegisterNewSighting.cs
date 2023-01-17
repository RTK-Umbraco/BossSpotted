using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.EntityFrameWork;

namespace BossSpotted.Models.BusinessDomain.Sightings
{
    public interface IRegisterNewSighting
    {
        void Register(int personId, SightingSeriousness seriousness);
    }
}
