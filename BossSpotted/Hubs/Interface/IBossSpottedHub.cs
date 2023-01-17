using BossSpotted.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BossSpotted.Hubs.Interface
{
    public interface IBossSpottedHub
    {
        Task BossSpotted(SightingSeriousness seriousness);
    }
}
