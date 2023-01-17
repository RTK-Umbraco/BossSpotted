using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.EntityFrameWork;

namespace BossSpotted.Models.BusinessDomain.Sightings
{
    public interface IRegisterNewSighting
    {
        bool Register(int personId, SightingSeriousness seriousness);
    }
}
