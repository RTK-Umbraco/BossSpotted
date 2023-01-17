using BossSpotted.Hubs.Interface;
using BossSpotted.Models.EntityFramework;
using Microsoft.AspNetCore.SignalR;

namespace BossSpotted.Hubs
{
    public class BossSpottedHub : Hub, IBossSpottedHub
    {
        private readonly IHubContext<BossSpottedHub> _hubContext;
        public BossSpottedHub(IHubContext<BossSpottedHub> hubContext)
        {
            this._hubContext = hubContext;
        }
        public async Task BossSpotted(SightingSeriousness seriousness)
        {
            await _hubContext.Clients.All.SendAsync("BossHasBeenSpotted", (int)seriousness);
        }
    }
}
 